using Dashboard.Application.DTOs.Customers;
using Dashboard.Application.DTOs.ExpertNotes;
using Dashboard.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Commands.ExpertNotes
{
    public sealed record UpdateExpertNoteCommand(UpdateExpertNote dto) : IRequest<Result<Unit>>;

}
