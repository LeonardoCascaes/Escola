using Escola.Domain.Commands.UserCommands;
using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Handlers.Interfaces;

namespace Escola.Domain.Handlers.UserHandlers
{
    public class CreateUserHandler : IHandler<CreateUserCommand>
    {
        private readonly IUserRepository<User> _userRepository;

        public CreateUserHandler(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(CreateUserCommand command)
        {
            command.Validate();
            if(!command.IsValid())
                return new GenericCommandResult(false, "Ocorreu um problema ao tentar executar a tarefa.", command.Notifications);

            var user = new User(command.Name, command.LastName, command.Email, command.BirthDate);

            await _userRepository.Create(user);

            return new GenericCommandResult(false, "Usuario cadastrado com sucesso.", new GenericOutput(user.Id, command));
        }
    }
}
