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
    public static class ExpertNoteQueries
    {
        public static Expression<Func<ExpertNote, ExpertNoteDto>> ProjectToDto()
        {
            return n => new ExpertNoteDto
            {
                Id = n.Id,
                Note = n.Note,
                CustomerId = n.CustomerId
               
            };

        }
    }
}
