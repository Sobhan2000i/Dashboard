using Dashboard.Application.DTOs.Customers;
using Dashboard.Application.Interfaces;
using MediatR;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Queries.Customer
{
    public sealed class GetAllCustomersQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<GetAllCustomersQuery, List<CustomerDto>?>
    {
        public async Task<List<CustomerDto>?> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            List<CustomerDto>? customers = await customerRepository.GetAllAsync();
            return customers;

        }
    }
}
