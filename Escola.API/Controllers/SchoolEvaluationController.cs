using Escola.Domain.Commands.SchoolEvaluationCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.SchoolEvaluationHandlers;
using Escola.Domain.RepositoryInterfaces;
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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolEvaluation>>> GetAll(
            [FromServices] ISchoolEvaluationRepository<SchoolEvaluation> repository
        )
        {
            try
            {
                var schoolEvaluations = await repository.GetAll();
                if (schoolEvaluations == null)
                    return Ok("O sistema não possui avaliações cadastradas.");
                return Ok(schoolEvaluations);
            }
            catch (Exception)
            {
                return BadRequest("Err002SE - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }


        [HttpGet("{schoolEvaluationId}")]
        public async Task<ActionResult<SchoolEvaluation>> Get(
            int schoolEvaluationId,
            [FromServices] ISchoolEvaluationRepository<SchoolEvaluation> repository
        )
        {
            try
            {
                var schoolEvaluation = await repository.Get(schoolEvaluationId);
                if (schoolEvaluation == null)
                    return Ok("Avaliação não encontrada.");
                return Ok(schoolEvaluation);
            }
            catch (Exception)
            {
                return BadRequest("Err003SE - Desculpe! Ocorreu uma falha interna no servidor, favor comunicar o administrador.");
            }
        }
    }
}
