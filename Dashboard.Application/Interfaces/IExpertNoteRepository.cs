using Dashboard.Application.DTOs.Customers;
using Dashboard.Application.DTOs.ExpertNotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Interfaces
{
    public interface IExpertNoteRepository
    {
        Task<List<ExpertNoteDto>> GetCustomerExpertNoteAsync(int id);
        Task<ExpertNoteDto> GetCustomerExpertNoteByIdAsync(int customerid, int expertId);
        Task<int> AddExpertNoteAsync(AddExpertNoteDto expertNote);
        Task DeleteExpertNoteAsync(int id);
        Task UpdateExpertNoteAsync(ExpertNoteDto expertNoteDto);
    }
}
