using Escola.Domain.Commands.SchoolRecordCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.SchoolRecordHandlers;
using Escola.Domain.RepositoryInterfaces;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolRecord>>> GetAll(
            [FromServices] ISchoolRecordRepository<SchoolRecord> repository
        )
        {
            try
            {
                var schoolRecords = await repository.GetAll();
                if (schoolRecords == null)
                    return Ok("O sistema não possui historicos escolares cadastrados.");
                return Ok(schoolRecords);
            }
            catch (Exception)
            {
                return BadRequest("Err002SR - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }


        [HttpGet("{schoolRecordId}")]
        public async Task<ActionResult<SchoolRecord>> Get(
            int schoolRecordId,
            [FromServices] ISchoolRecordRepository<SchoolRecord> repository
        )
        {
            try
            {
                var schoolRecord = await repository.Get(schoolRecordId);
                if (schoolRecord == null)
                    return Ok("Historico escolar não encontrado.");
                return Ok(schoolRecord);
            }
            catch (Exception)
            {
                return BadRequest("Err003SR - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }
    }
}
