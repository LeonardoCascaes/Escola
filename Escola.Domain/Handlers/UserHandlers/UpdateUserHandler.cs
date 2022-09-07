using Escola.Domain.Commands.UserCommands;
using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Handlers.Interfaces;

namespace Escola.Domain.Handlers.UserHandlers
{
    public class UpdateUserHandler : IHandler<UpdateUserCommand>
    {
        private readonly IUserRepository<User> _userRepository;

        public UpdateUserHandler(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(UpdateUserCommand command)
        {
            command.Validate();
            if (!command.IsValid())
                return new GenericCommandResult(false, "Ocorreu um problema ao tentar executar a tarefa.", command.Notifications);

            var user = await _userRepository.Get(command.Id);
            if(user == null)
                return new GenericCommandResult(false, "Falha ao encontrar o usuario.", null);

            user.ChangeName(command.Name);
            user.ChangeLastName(command.LastName);
            user.ChangeEmail(command.Email);
            user.ChangeBirthDate(command.BirthDate);
            user.ChangeModificationDate();

            await _userRepository.Update(user);
            return new GenericCommandResult(true, "Usuario atualizado com sucesso.", new GenericOutput(user.Id, command));
        }
    }
}
