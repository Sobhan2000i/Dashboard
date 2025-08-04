using Dashboard.Application.DTOs.Customers;
using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.DTOs.Queries
{
    public static class CustomerQueries
    {
        public static Expression<Func<Customer, CustomerDto>> ProjectToDto()
        {
            return n => new CustomerDto
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
            };
        }
    }

}
