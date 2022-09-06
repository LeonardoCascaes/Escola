using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using Escola.Shared.Commands.Interfaces;

namespace Escola.Domain.Handlers.UserHandlers
{
    public class DeleteUserHandler
    {
        private readonly IUserRepository<User> _userRepository;

        public DeleteUserHandler(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(int userId)
        {
            var user = await _userRepository.Get(userId);
            if (user == null)
                return new GenericCommandResult(false, "Falha ao encontrar o usuario.", null);

            await _userRepository.Delete(user);
            return new GenericCommandResult(true, "Usuario deletado com sucesso!", user.Id);
        }
    }
}
