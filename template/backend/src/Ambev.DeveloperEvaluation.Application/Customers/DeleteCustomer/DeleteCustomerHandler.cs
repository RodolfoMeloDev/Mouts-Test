using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<DeleteCustomerResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCustomerCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _customerRepository.DeleteAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Customer with ID {request.Id} not found");

            return new DeleteCustomerResult { Success = true };
        }
    }
}
