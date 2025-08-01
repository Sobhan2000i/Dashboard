using Dashboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Domain.Entities
{
    public sealed class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? CellPhone { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public CustomerLevel? Level { get; set; }
        public DateTime RegisteredAt { get; set; }
        public int LoyaltyScore { get; set; }
        public int Credit { get; set; }
        public int OpenTickets { get; set; }
        public long MobilePurchaseAmountLastSixMonths { get; set; }
        public long NonMobilePurchaseAmountLastSixMonths { get; set; }
        public DateTime LastLoginedAt { get; set; }
        public TimeSpan TimeSinceLastPurchase { get; set; }
        public List<ExpertNote>? ExpertNotes { get; set; }
        public List<Ticket>? Tickets { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdaterId { get; set; }
    }
}
