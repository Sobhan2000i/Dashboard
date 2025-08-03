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
        public int Id { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public int CustomerId { get; private set; }
        public Status Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? ExternalLink { get; private set; }
        public Customer? Customer { get; private set; }

        private Ticket() { }
        

    }
}
