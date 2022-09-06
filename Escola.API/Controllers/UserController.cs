using Escola.Domain.Commands.UserCommands;
using Escola.Domain.Handlers.UserHandlers;
using Escola.Shared.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<GenericCommandResult>> Create(
            [FromBody] CreateUserCommand command,
            [FromServices] CreateUserHandler handler)
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
                return BadRequest("Err001U - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }

        [HttpPut]
        public async Task<ActionResult<GenericCommandResult>> Update(
            [FromBody] UpdateUserCommand command,
            [FromServices] UpdateUserHandler handler)
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
                return BadRequest("Err002U - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<GenericCommandResult>> Delete(
            int userId,
            [FromServices] DeleteUserHandler handler)
        {
            try
            {
                var result = (GenericCommandResult)await handler.Handle(userId);
                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Err003U - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }
    }
}
