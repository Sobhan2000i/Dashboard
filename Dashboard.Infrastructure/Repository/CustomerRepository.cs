using Dashboard.Application.DTOs.Customers;
using Dashboard.Application.DTOs.Queries;
using Dashboard.Application.Interfaces;
using Dashboard.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.Repository
{
    public sealed class CustomerRepository(ApplicationDbContext applicationDbContext) : ICustomerRepository
    {
        public async Task<List<CustomerDto>> GetAllAsync()
        {
            List<CustomerDto> customers = await applicationDbContext.Customers
                .Select(CustomerQueries.ProjectToDto())
                .ToListAsync();

            return customers;
        }

        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            CustomerDto? customers = await applicationDbContext.Customers
                .Where(c => c.Id == id)
                .Select(CustomerQueries.ProjectToDto())
                .FirstOrDefaultAsync();
            if (customers is null)
            {
                return null;
            }
            return customers;
        }
    }
}
