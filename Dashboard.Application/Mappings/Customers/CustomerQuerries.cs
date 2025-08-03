using Dashboard.Application.DTOs.Customers;
using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Mappings.Customers
{
    public static class CustomerQuerries
    {
        public static Expression<Func<Customer, CustomerWithExpertNoteDto>> ProjectToCustomerWithExpertNotesDto()
        {
            return h => new CustomerWithExpertNoteDto
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
            };
        }
    }
}
