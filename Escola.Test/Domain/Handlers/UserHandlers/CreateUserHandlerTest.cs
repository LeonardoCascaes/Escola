using Escola.Domain.Commands.UserCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.UserHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.Handlers.UserHandlers
{
    public class CreateUserHandlerTest
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly CreateUserCommand _validCommand;
        private readonly CreateUserCommand _invalidCommand;

        public CreateUserHandlerTest()
        {
            _userRepository = Substitute.For<IUserRepository<User>>();
            _validCommand = new CreateUserCommand("Leonardo", "Cascaes", "leonardo@cascaes.com", DateTime.UtcNow.AddYears(-28));
            _invalidCommand = new CreateUserCommand("Leo", "C", "leonardo.com", DateTime.UtcNow.AddDays(5));
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Criacao_Do_Usuario_Caso_Der_Problema_Na_Validacao_Do_Command()
        {
            //Arrange
            var handler = new CreateUserHandler(_userRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_invalidCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Deve_Obter_Sucesso_Para_A_Criacao_Do_Usuario()
        {
            //Arrange
            var handler = new CreateUserHandler(_userRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.True(result.Success);
        }
    }
}
