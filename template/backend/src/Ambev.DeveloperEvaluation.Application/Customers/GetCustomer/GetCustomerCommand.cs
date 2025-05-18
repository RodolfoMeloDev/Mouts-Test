using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer
{
    public class GetCustomerCommand : IRequest<GetCustomerResult>
    {
        public int Id { get; }

        public GetCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
