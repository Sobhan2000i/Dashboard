using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.DTOs.ExpertNotes
{
    public sealed class UpsertsExpertNoteDto
    {
        public int CustomerId { get; set; }
        public string? Note { get; set; }
        public string? CreaterId { get; set; }
    }
}
