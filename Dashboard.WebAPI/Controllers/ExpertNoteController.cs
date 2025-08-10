using Dashboard.Application.Commands.ExpertNotes;
using Dashboard.Application.DTOs.ExpertNotes;
using Dashboard.Application.Queries.Customer;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.WebAPI.Controllers
{
    [ApiController]
    [Route("customers/{customerId}/expertnotes")]
    [Authorize]
    public class ExpertNoteController(IMediator mediatR) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCustomerExpertNotes(AddExpertNoteDto addExpertNoteDto)
        {
            var expertNoteResult = await mediatR.Send(new AddExpertNoteCommand(addExpertNoteDto));
            
            if (!expertNoteResult.IsSuccess)
            {
                return Problem(
                   detail: "Customer was not found.",
                   statusCode: StatusCodes.Status400BadRequest,
                   extensions: new Dictionary<string, object?>
                   {
                { "errors", expertNoteResult.Errors }
                   });
            }
            return Ok(expertNoteResult.Data);

        }
    }
}
