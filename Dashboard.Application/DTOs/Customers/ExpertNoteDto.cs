using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.DTOs.Customers
{
    public sealed class ExpertNoteDto
    {
        public int Id { get;  init; }
        public string? Note { get;  init; }
        public DateTime CreatedAt { get;  init; }
        public DateTime UpdatedAt { get;  init; }
        public bool IsDeleted { get;  init; } = false;

    }
}
