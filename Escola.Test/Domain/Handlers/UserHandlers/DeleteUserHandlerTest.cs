using Escola.Domain.Entities;
using Escola.Domain.Handlers.UserHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.Handlers.UserHandlers
{
    public class DeleteUserHandlerTest
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly User _user;
        private const int userId = 10;


        public DeleteUserHandlerTest()
        {
            _userRepository = Substitute.For<IUserRepository<User>>();
            _user = new User("Rafael", "AlgumaCoisa", "Rafal@test.com", DateTime.UtcNow.AddYears(-15));
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_Deletar_O_Usuario_Ao_Tentar_Encontrar_O_Usuario()
        {
            //Arrange
            var handler = new DeleteUserHandler(_userRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(userId);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Deve_Obter_Sucesso_Para_Deletar_O_Usuario()
        {
            //Arrange
            var handler = new DeleteUserHandler(_userRepository);
            _userRepository.Get(userId).Returns(_user);

            //Act
            var result = (GenericCommandResult)await handler.Handle(userId);

            //Assert
            Assert.True(result.Success);
        }
    }
}
