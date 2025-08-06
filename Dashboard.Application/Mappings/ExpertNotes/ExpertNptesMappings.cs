using Dashboard.Application.DTOs.ExpertNotes;
using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Mappings.ExpertNotes
{
    public static class ExpertNptesMappings
    {
        public static ExpertNote ToEntity(this UpsertsExpertNoteDto addExpertNoteDto)
        {
            return new ExpertNote(addExpertNoteDto.CustomerId , addExpertNoteDto.Note! , addExpertNoteDto.CreaterId!);
        }
    }
}
