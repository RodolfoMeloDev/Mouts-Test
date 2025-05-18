using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerItensRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IOrderRepository orderRepository, ICustomerRepository customerItensRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _customerItensRepository = customerItensRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var order = _mapper.Map<Order>(request);
            order.DateOrder = order.DateOrder.ToUniversalTime();
            var items = _mapper.Map<List<OrderItens>>(request.Itens);

            var customer = await _customerItensRepository.GetByIdAsync(order.CustomerId) ??
                throw new InvalidOperationException($"Customer ID {order.CustomerId} not exists");

            if (!customer.Status.Equals(CustomerStatus.Active))
                throw new InvalidOperationException($"Customer ID [{order.CustomerId}] not active");

            var productGroup = request.Itens.GroupBy(i => i.ProductId)
                                            .Select(g => new { ProductId = g.Key, TotalQuantities = g.Sum(i => i.Quantities) });

            var products = await _productRepository.GetByListIdAsync(productGroup.Select(s => s.ProductId).ToList()) ??
                throw new InvalidOperationException($"Products IDs [{string.Join(",", productGroup.Select(s => s.ProductId).ToList())}] not exits");

            var productsNotExist = productGroup.Select(s => s.ProductId).ToList().Except(products.Select(s => s.Id));

            if (productsNotExist.Any())
                throw new InvalidOperationException($"Products IDs [{string.Join(",", productsNotExist)}] not exits");

            var productsInvalid = products.Where(f => !f.Status.Equals(ProductStatus.Active)).Select(s => s.Id).ToList();

            if (productsInvalid.Any())
                throw new InvalidOperationException($"Products IDs [{string.Join(",", productsInvalid)}] not active");

            items.ForEach(i => {
                i.Discount = SetDiscount(i.Quantities, i.UnitPrice, productGroup.Where(f => f.ProductId.Equals(i.ProductId)).FirstOrDefault()!.TotalQuantities);
                i.TotalPrice = (i.Quantities * i.UnitPrice) - (decimal)i.Discount;
            });

            order.Itens = items;
            order.TotalOrder = order.Itens.Sum(x => x.TotalPrice);

            var createdOrder = await _orderRepository.CreateAsync(order, cancellationToken);

            var result = _mapper.Map<CreateOrderResult>(createdOrder);
            return result;
        }

        private static decimal SetDiscount(int quantities, decimal unitPrice, int totalItens)
        {
            if (totalItens < 4)
                return 0;

            if (totalItens < 10)
                return ((quantities * unitPrice) * 0.1m);

            return ((quantities * unitPrice) * 0.2m);
        }
    }
}
