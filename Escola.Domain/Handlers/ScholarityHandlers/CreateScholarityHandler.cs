using Escola.Domain.Commands.ScholarityCommands;
using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Handlers.Interfaces;

namespace Escola.Domain.Handlers.ScholarityHandlers
{
    public class CreateScholarityHandler : IHandler<CreateScholarityCommand>
    {
        private readonly IScholarityRepository<Scholarity> _scholarityRepository;
        private readonly IUserRepository<User> _userRepository;

        public CreateScholarityHandler(IScholarityRepository<Scholarity> scholarityRepository, IUserRepository<User> userRepository)
        {
            _scholarityRepository = scholarityRepository;
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(CreateScholarityCommand command)
        {
            command.Validate();
            if (!command.IsValid())
                return new GenericCommandResult(false, "Ocorreu um problema ao tentar executar a tarefa.", command.Notifications);

            var user = await _userRepository.Get(command.UserId);
            if(user == null)
                return new GenericCommandResult(false, "Falha ao encontrar o usuario.", null);

            var userScholarity = await _scholarityRepository.GetScholarityByUserId(command.UserId);
            if(userScholarity != null)
                return new GenericCommandResult(false, "Este usuario já possui uma escolaridade.", null);

            var scholarity = new Scholarity(command.Description ,command.UserId);
            await _scholarityRepository.Create(scholarity);

            return new GenericCommandResult(true, "Escolaridade cadastrada com sucesso.", new GenericOutput(scholarity.Id, command));
        }
    }
}
