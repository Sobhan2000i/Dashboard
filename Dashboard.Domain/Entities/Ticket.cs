using Dashboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Domain.Entities
{
    public sealed class Ticket
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int CustomerId { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ExternalLink { get; set; }

    }
}
