using Escola.Domain.Commands.UserCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.UserHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll(
            [FromServices] IUserRepository<User> repository    
        )
        {
            try
            {
                var users = await repository.GetAll();
                if (users == null)
                    return Ok("O sistema não possui usuarios cadastrados.");
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest("Err002U - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }


        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> Get(
            int userId,
            [FromServices] IUserRepository<User> repository
        )
        {
            try
            {
                var user = await repository.Get(userId);
                if (user == null)
                    return Ok("Usuario não encontrado.");
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest("Err003U - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
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
                return BadRequest("Err004U - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
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
                return BadRequest("Err005U - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }
    }
}
