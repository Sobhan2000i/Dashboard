using Dashboard.Domain.Entities;
using Dashboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.DTOs.Customers
{
    public sealed class CustomerWithExpertNoteDto
    {
        public int Id { get;  init; }
        public string? Name { get; init; }
        public string? Lastname { get; init; }
        public string? CellPhone { get; init; }
        public string? City { get; init; }
        public string? Province { get; init; }
        public CustomerLevel? Level { get; init; }
        public DateTime RegisteredAt { get; init; }
        public int LoyaltyScore { get; init; }
        public int Credit { get; init; }
        public int OpenTickets { get; init; }
        public long MobileSpent { get; init; }
        public long NonMobileSpent { get; init; }
        public DateTime LastLoginedAt { get; init; }
        public TimeSpan TimeSinceLastPurchase { get; init; }
        public List<ExpertNote>? ExpertNotes { get; init; }
        public List<Ticket>? Tickets { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public int? UpdaterId { get; init; }
    }
}
