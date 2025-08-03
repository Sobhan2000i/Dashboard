using Dashboard.Domain.Entities;
using Dashboard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.DTOs.Customers
{
    public sealed class TicketDto
    {
        public int Id { get;  init; }
        public string? Title { get;  init; }
        public string? Description { get;  init; }
        public Status Status { get;  init; }
        public DateTime CreatedAt { get;  init; }
        public string? ExternalLink { get;  init; }
    }
}
