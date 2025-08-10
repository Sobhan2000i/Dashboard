using Dashboard.Application.Interfaces;
using Dashboard.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Commands.ExpertNotes
{
    public sealed class UpdateExpertNoteCommandhandler(IExpertNoteRepository expertNoteRepository) : IRequestHandler<UpdateExpertNoteCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(UpdateExpertNoteCommand request, CancellationToken cancellationToken)
        {
            if (await expertNoteRepository.GetCustomerExpertNoteByIdAsync(request.dto.CustomerId, request.dto.Id) == null)
            {
                var errors = new Dictionary<string, string[]>
                {
                    { "error", new[] { $"Customer with id {request.dto.CustomerId} doesn't exists." } }
                };
                return Result<Unit>.Failure(errors);
            }
            if (await expertNoteRepository.GetExpertNoteById (request.dto.Id) == null)
            {
                var errors = new Dictionary<string, string[]>
                {
                    { "error", new[] { $"ExpertNote with id {request.dto.Id} doesn't exists." } }
                };
                return Result<Unit>.Failure(errors);
            }

            await expertNoteRepository.UpdateExpertNoteAsync(request.dto);

            return Result<Unit>.Success(new List<Unit> { Unit.Value });
        }
    }
}
