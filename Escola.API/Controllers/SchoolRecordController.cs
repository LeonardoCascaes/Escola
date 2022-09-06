using Escola.Domain.Commands.SchoolRecordCommands;
using Escola.Domain.Handlers.SchoolRecordHandlers;
using Escola.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SchoolRecordController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<GenericCommandResult>> Create(
            [FromBody] CreateSchoolRecordCommand command,
            [FromServices] CreateSchoolRecordhandler handler)
        {
            try
            {
                var result = (GenericCommandResult)await handler.Handle(command);
                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Err001SR - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }
    }
}
