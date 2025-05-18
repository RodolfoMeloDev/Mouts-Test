using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var customer = _mapper.Map<Customer>(request);

            var updated = await _customerRepository.UpdateAsync(customer, cancellationToken);
            var result = _mapper.Map<UpdateCustomerResult>(updated);
            return result;
        }
    }
}
