using Dashboard.Application.DTOs.Customers;
using Dashboard.Application.DTOs.ExpertNotes;
using Dashboard.Application.Interfaces;
using Dashboard.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Application.Mappings.ExpertNotes;

namespace Dashboard.Infrastructure.Repository
{
    public sealed class ExpertNoteRepository(ApplicationDbContext applicationDbContext) : IExpertNoteRepository
    {
        public async Task<int> AddExpertNoteAsync(AddExpertNoteDto expertNote)
        {
            //check of the customer exists

            var expertnotes = expertNote.ToEntity();
            applicationDbContext.ExpertNotes.Add(expertnotes);
            await applicationDbContext.SaveChangesAsync();

            return expertnotes.Id;
        }

        public Task DeleteExpertNoteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExpertNoteDto>> GetCustomerExpertNoteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ExpertNoteDto> GetCustomerExpertNoteByIdAsync(int customerid, int expertId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExpertNoteAsync(ExpertNoteDto expertNoteDto)
        {
            throw new NotImplementedException();
        }
    }
}
