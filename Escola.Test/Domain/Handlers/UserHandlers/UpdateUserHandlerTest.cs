using Escola.Domain.Commands.UserCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.UserHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.Handlers.UserHandlers
{
    public class UpdateUserHandlerTest
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly UpdateUserCommand _validCommand;
        private readonly UpdateUserCommand _invalidCommand;
        private readonly User _user;

        public UpdateUserHandlerTest()
        {
            _userRepository = Substitute.For<IUserRepository<User>>();
            _validCommand = new UpdateUserCommand(1, "Leonardo", "Cascaes", "leonardo@cascaes.com", DateTime.UtcNow.AddYears(-28));
            _invalidCommand = new UpdateUserCommand(1, "Leo", "C", "leonardo.com", DateTime.UtcNow.AddDays(5));
            _user = new User("Rafael", "AlgumaCoisa", "Rafal@test.com", DateTime.UtcNow.AddYears(-15));
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Edicao_Do_Usuario_Caso_Der_Problema_Na_Validacao_Do_Command()
        {
            //Arrange
            var handler = new UpdateUserHandler(_userRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_invalidCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Edicao_Do_Usuario_Caso_Nao_Encontrar_O_Usuario()
        {
            //Arrange
            var handler = new UpdateUserHandler(_userRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Deve_Obter_Sucesso_Para_A_Edicao_Do_Usuario()
        {
            //Arrange
            var handler = new UpdateUserHandler(_userRepository);
            _userRepository.Get(_validCommand.Id).Returns(_user);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.True(result.Success);
        }
    }
}
