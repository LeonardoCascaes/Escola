using Escola.Domain.Commands.ScholarityCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.ScholarityHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ScholarityController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<GenericCommandResult>> Create(
            [FromBody] CreateScholarityCommand command,
            [FromServices] CreateScholarityHandler handler)
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
                return BadRequest("Err001SC - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scholarity>>> GetAll(
            [FromServices] IScholarityRepository<Scholarity> repository
        )
        {
            try
            {
                var scholarities = await repository.GetAll();
                if (scholarities == null)
                    return Ok("O sistema não possui escolaridades cadastradas.");
                return Ok(scholarities);
            }
            catch (Exception)
            {
                return BadRequest("Err002SC - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }


        [HttpGet("{scholarityId}")]
        public async Task<ActionResult<Scholarity>> Get(
            int scholarityId,
            [FromServices] IScholarityRepository<Scholarity> repository
        )
        {
            try
            {
                var scholarity = await repository.Get(scholarityId);
                if (scholarity == null)
                    return Ok("Escolaridade não encontrada.");
                return Ok(scholarity);
            }
            catch (Exception)
            {
                return BadRequest("Err003SC - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }

        [HttpPut]
        public async Task<ActionResult<GenericCommandResult>> Update(
            [FromBody] UpdateScholarityCommand command,
            [FromServices] UpdateScholarityHandler handler)
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
                return BadRequest("Err004SC - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }

        [HttpDelete("{scholarityId}")]
        public async Task<ActionResult<GenericCommandResult>> Delete(
            int scholarityId,
            [FromServices] DeleteScholarityHandler handler)
        {
            try
            {
                var result = (GenericCommandResult)await handler.Handle(scholarityId);
                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest("Err005SC - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }
    }
}
