using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

public class CreateCustomerRequest
{
    public string CustomerName { get; set; } = string.Empty;

    public DateTime Birthday { get; set; }

    public string Address { get; set; } = string.Empty;

    public string NumberAdrress { get; set; } = string.Empty;

    public string Complement { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public CustomerStatus Status { get; set; }
}
