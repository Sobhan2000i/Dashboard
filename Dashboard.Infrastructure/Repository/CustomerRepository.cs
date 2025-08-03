using Dashboard.Application.DTOs.Customers;
using Dashboard.Application.Interfaces;
using Dashboard.Application.Mappings.Customers;
using Dashboard.Domain.Entities;
using Dashboard.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Infrastructure.Repository
{
    public sealed class CustomerRepository(ApplicationDbContext applicationDbContext) : ICustomerRepository
    {
        public async Task<IEnumerable<CustomerWithExpertNoteDto>> GetAllAsync()
        {
            List<CustomerWithExpertNoteDto> customers = applicationDbContext.Customers.Select( h => new CustomerWithExpertNoteDto
            {
                Id = h.Id,
                Name = h.Name,
                Lastname = h.Lastname,
                CellPhone = h.CellPhone,
                City = h.City,
                Province = h.Province,
                Level = h.Level,
                RegisteredAt = h.RegisteredAt,
                LoyaltyScore = h.LoyaltyScore,
                Credit = h.Credit,
                OpenTickets = h.OpenTickets,
                MobileSpent = h.MobileSpent,
                NonMobileSpent = h.NonMobileSpent,
                LastLoginedAt = h.LastLoginedAt,
                TimeSinceLastPurchase = h.TimeSinceLastPurchase,
                ExpertNotes = h.ExpertNotes,
                Tickets = h.Tickets,
                UpdatedAt = h.UpdatedAt,
                UpdaterId = h.UpdaterId
            });
            return customers;
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
