using Dashboard.Application.Interfaces;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Commands.ExpertNotes
{
    public sealed class AddExpertNoteCommandHandler(IExpertNoteRepository expertNoteRepository , ICustomerRepository customerRepository) : IRequestHandler<AddExpertNoteCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(AddExpertNoteCommand request, CancellationToken cancellationToken)
        {
            if (await customerRepository.GetByIdAsync(request.AddExpertNoteDto.CustomerId) == null)
            {
                Dictionary<string, string[]> error = new Dictionary<string, string[]>
                {
                    { "error", new[] { $"Customer with id {request.AddExpertNoteDto.CustomerId} doesn't exist." } }
                };

                return Result<int>.Failure(error);
            }

            return Result<int>.Success(new List<int> (await expertNoteRepository.AddExpertNoteAsync(request.AddExpertNoteDto)));
        }
    }
}
