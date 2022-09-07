using Escola.Domain.Commands.SchoolEvaluationCommands;
using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Handlers.Interfaces;

namespace Escola.Domain.Handlers.SchoolEvaluationHandlers
{
    public class CreateSchoolEvaluationHandler : IHandler<CreateSchoolEvaluationCommand>
    {
        private readonly ISchoolRecordRepository<SchoolRecord> _schoolRecordRepository;
        private readonly ISchoolEvaluationRepository<SchoolEvaluation> _schoolEvaluationRepository;

        public CreateSchoolEvaluationHandler(ISchoolRecordRepository<SchoolRecord> schoolRecordRepository, ISchoolEvaluationRepository<SchoolEvaluation> schoolEvaluationRepository)
        {
            _schoolRecordRepository = schoolRecordRepository;
            _schoolEvaluationRepository = schoolEvaluationRepository;
        }

        public async Task<ICommandResult> Handle(CreateSchoolEvaluationCommand command)
        {
            command.Validate();
            if (!command.IsValid())
                return new GenericCommandResult(false, "Ocorreu um problema ao tentar executar a tarefa.", command.Notifications);

            var schoolRecord = await _schoolRecordRepository.Get(command.SchoolRecordId);
            if (schoolRecord == null)
                return new GenericCommandResult(false, "Falha ao encontrar o historico escolar.", null);

            var schoolEvaluation = new SchoolEvaluation(command.Matter, command.Grade, command.SchoolRecordId);
            await _schoolEvaluationRepository.Create(schoolEvaluation);

            return new GenericCommandResult(true, "Avaliação cadastrada com sucesso.", new GenericOutput(schoolEvaluation.Id, command));
        }
    }
}
