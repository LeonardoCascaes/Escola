using Escola.Domain.Commands.SchoolRecordCommands;
using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Handlers.Interfaces;

namespace Escola.Domain.Handlers.SchoolRecordHandlers
{
    public class CreateSchoolRecordhandler : IHandler<CreateSchoolRecordCommand>
    {
        private readonly ISchoolRecordRepository<SchoolRecord> _schoolRecordRepository;
        private readonly IUserRepository<User> _userRepository;

        public CreateSchoolRecordhandler(ISchoolRecordRepository<SchoolRecord> schoolRecordRepository, IUserRepository<User> userRepository)
        {
            _schoolRecordRepository = schoolRecordRepository;
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(CreateSchoolRecordCommand command)
        {
            command.Validate();
            if (!command.IsValid())
                return new GenericCommandResult(false, "Ocorreu um problema ao tentar executar a tarefa.", command.Notifications);

            var user = await _userRepository.Get(command.UserId);
            if (user == null)
                return new GenericCommandResult(false, "Falha ao encontrar o usuario.", null);

            var userSchoolRecord = await _schoolRecordRepository.GetSchoolRecordByUserId(command.UserId);
            if (userSchoolRecord != null)
                return new GenericCommandResult(false, "Este usuario já possui um historico escolar.", null);

            var schoolRecord = new SchoolRecord(command.YearOfCompletion, command.UserId);
            await _schoolRecordRepository.Create(schoolRecord);

            return new GenericCommandResult(true, "Historico escolar cadastrado com sucesso.", new GenericOutput(schoolRecord.Id, command));
        }
    }
}
