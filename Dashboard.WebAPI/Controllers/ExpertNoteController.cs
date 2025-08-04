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
        //[HttpGet]
        //public async Task<IActionResult> GetAllCustomerExpertNotes()
        //{

        //}
    }
}
