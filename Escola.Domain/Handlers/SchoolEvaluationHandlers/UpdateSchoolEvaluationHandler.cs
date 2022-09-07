using Escola.Domain.Commands.SchoolEvaluationCommands;
using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Handlers.Interfaces;

namespace Escola.Domain.Handlers.SchoolEvaluationHandlers
{
    public class UpdateSchoolEvaluationHandler : IHandler<UpdateSchoolEvaluationCommand>
    {
        private readonly ISchoolEvaluationRepository<SchoolEvaluation> _schoolEvaluationRepository;

        public UpdateSchoolEvaluationHandler(ISchoolEvaluationRepository<SchoolEvaluation> schoolEvaluationRepository)
        {
            _schoolEvaluationRepository = schoolEvaluationRepository;
        }

        public async Task<ICommandResult> Handle(UpdateSchoolEvaluationCommand command)
        {
            command.Validate();
            if (!command.IsValid())
                return new GenericCommandResult(false, "Ocorreu um problema ao tentar executar a tarefa.", command.Notifications);

            var schoolEvaluation = await _schoolEvaluationRepository.Get(command.Id);
            if(schoolEvaluation == null)
                return new GenericCommandResult(false, "Falha ao encontrar a avaliação.", null);

            schoolEvaluation.ChangeMatter(command.Matter);
            schoolEvaluation.ChangeGrade(command.Grade);
            schoolEvaluation.ChangeModificationDate();

            await _schoolEvaluationRepository.Update(schoolEvaluation);
            return new GenericCommandResult(true, "Avaliação atualizada com sucesso.", new GenericOutput(schoolEvaluation.Id, command));
        }
    }
}
