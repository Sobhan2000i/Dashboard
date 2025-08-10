using Dashboard.Application.DTOs.Auth;
using Dashboard.Application.DTOs.Customers;
using Dashboard.Application.DTOs.ExpertNotes;
using Dashboard.Application.DTOs.Queries;
using Dashboard.Application.Interfaces;
using Dashboard.Application.Mappings.ExpertNotes;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Shared;
using Dashboard.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Infrastructure.Repository
{
    public sealed class ExpertNoteRepository(ApplicationDbContext applicationDbContext) : IExpertNoteRepository
    {
        public async Task<int> AddExpertNoteAsync(AddExpertNoteDto expertNote)
        {

            var expertnotes = expertNote.ToEntity();
            applicationDbContext.ExpertNotes.Add(expertnotes);
            await applicationDbContext.SaveChangesAsync();

            return expertnotes.Id;
        }

        public Task DeleteExpertNoteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExpertNoteDto>> GetCustomerExpertNoteAsync(int id)
        {
            return await applicationDbContext.ExpertNotes.Where(e => e.CustomerId == id).Select(ExpertNoteQueries.ProjectToDto()).ToListAsync();
        }

        public async Task<ExpertNoteDto?> GetCustomerExpertNoteByIdAsync(int customerid, int expertId)
        {
            return await applicationDbContext.ExpertNotes.Where(e => e.CustomerId == customerid && e.Id == expertId).Select(ExpertNoteQueries.ProjectToDto()).FirstOrDefaultAsync();
        }

        public async Task<ExpertNote?> GetExpertNoteById(int expertnoteId)
        {
            var expertNote = await applicationDbContext.ExpertNotes
                .FirstOrDefaultAsync(e => e.Id == expertnoteId);
            return expertNote;

        }

        public async Task UpdateExpertNoteAsync(UpdateExpertNote expertNoteDto)
        {
            var existingNote = await applicationDbContext.ExpertNotes
             .FirstOrDefaultAsync(e => e.Id == expertNoteDto.Id);

            existingNote!.Update(expertNoteDto.Note! , expertNoteDto.UpdaterId);

            await applicationDbContext.SaveChangesAsync();
        }
    }
}
