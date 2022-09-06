using Escola.Domain.Commands.SchoolEvaluationCommands;
using Escola.Domain.Handlers.SchoolEvaluationHandlers;
using Escola.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SchoolEvaluationController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<GenericCommandResult>> Create(
           [FromBody] CreateSchoolEvaluationCommand command,
           [FromServices] CreateSchoolEvaluationHandler handler)
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
                return BadRequest("Err001SE - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }
    }
}
