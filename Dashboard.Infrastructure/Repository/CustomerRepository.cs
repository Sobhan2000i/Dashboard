using Dashboard.Application.DTOs.Customers;
using Dashboard.Application.Interfaces;
using Dashboard.Application.Mappings.Customers;
using Dashboard.Domain.Enums;
using Dashboard.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Infrastructure.Repository
{
    public sealed class CustomerRepository(ApplicationDbContext applicationDbContext) : ICustomerRepository
    {
        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            List<CustomerDto> customers = await applicationDbContext.Customers
                .Select(n => new CustomerDto
                {
                    Id = n.Id,
                    Name = n.Name,
                    Lastname = n.Lastname,
                    CellPhone = n.CellPhone,
                    City = n.City,
                    Province = n.Province,
                    Level = n.Level,
                    RegisteredAt = n.RegisteredAt,
                    LoyaltyScore = n.LoyaltyScore,
                    Credit = n.Credit,
                    OpenTickets = n.OpenTickets,
                    MobileSpent = n.MobileSpent,
                    NonMobileSpent = n.NonMobileSpent,
                    LastLoginedAt = n.LastLoginedAt,
                    TimeSinceLastPurchase = n.TimeSinceLastPurchase,
                    ExpertNotes = n.ExpertNotes == null ? null : n.ExpertNotes
                        .Select(note => new ExpertNoteDto
                        {
                            Id = note.Id,
                            Note = note.Note,
                            CreatedAt = note.CreatedAt,
                            UpdatedAt = note.UpdatedAt
                        }).ToList(),
                    Tickets = n.Tickets == null ? null : n.Tickets
                        .Select(ticket => new TicketDto
                        {
                            Id = ticket.Id,
                            Title = ticket.Title,
                            Description = ticket.Description,
                            Status = ticket.Status,
                            CreatedAt = ticket.CreatedAt,
                            ExternalLink = ticket.ExternalLink
                        }).ToList(),
                    UpdatedAt = n.UpdatedAt,
                    UpdaterId = n.UpdaterId
                })
                .ToListAsync();

            return customers;
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
