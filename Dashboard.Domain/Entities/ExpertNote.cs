using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Domain.Entities
{
    public sealed class ExpertNote
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreaterId { get; set; }
    }
}
