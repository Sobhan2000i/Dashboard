using Dashboard.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Commands.ExpertNotes
{
    public sealed class UpdateExpertNoteCommandhandler(IExpertNoteRepository expertNoteRepository) : IRequestHandler<UpdateExpertNoteCommand>
    {
        public async Task Handle(UpdateExpertNoteCommand request, CancellationToken cancellationToken)
        {
            if (await expertNoteRepository.GetCustomerExpertNoteByIdAsync(request.ExpertNoteDto.CustomerId , request.ExpertNoteDto.Id) == null)
            {
                return;
            }
            //make it return Result
            await expertNoteRepository.UpdateExpertNoteAsync(request.ExpertNoteDto);
        }
    }
}
