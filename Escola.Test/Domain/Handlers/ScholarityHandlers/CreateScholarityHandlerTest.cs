using Escola.Domain.Commands.ScholarityCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.ScholarityHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.Handlers.ScholarityHandlers
{
    public class CreateScholarityHandlerTest
    {
        private readonly IScholarityRepository<Scholarity> _scholarityRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly CreateScholarityCommand _validCommand;
        private readonly CreateScholarityCommand _invalidCommand;
        private readonly Scholarity _scholarity;
        private readonly User _user;

        public CreateScholarityHandlerTest()
        {
            _scholarityRepository = Substitute.For<IScholarityRepository<Scholarity>>();
            _userRepository = Substitute.For<IUserRepository<User>>();
            _validCommand = new CreateScholarityCommand("Infantil", 1);
            _invalidCommand = new CreateScholarityCommand("Tecnologo", 3);
            _scholarity = new Scholarity("Medio", 1);
            _user = new User("Rafael", "AlgumaCoisa", "Rafal@test.com", DateTime.UtcNow.AddYears(-15));
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Criacao_Da_Escolaridade_Ao_Tentar_Validar_O_Command_No_Handler()
        {
            //Arrange
            var handler = new CreateScholarityHandler(_scholarityRepository, _userRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_invalidCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Criacao_Da_Escolaridade_Ao_Tentar_Encontrar_O_Usuario()
        {
            //Arrange
            var handler = new CreateScholarityHandler(_scholarityRepository, _userRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Criacao_Da_Escolaridade_Caso_O_Usuario_Ja_Tenha_Uma_Cadastrada()
        {
            //Arrange
            var handler = new CreateScholarityHandler(_scholarityRepository, _userRepository);
            _userRepository.Get(_validCommand.UserId).Returns(_user);
            _scholarityRepository.GetScholarityByUserId(_validCommand.UserId).Returns(_scholarity);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Deve_Obter_Sucesso_Para_A_Criacao_Da_Escolaridade()
        {
            //Arrange
            var handler = new CreateScholarityHandler(_scholarityRepository, _userRepository);
            _userRepository.Get(_validCommand.UserId).Returns(_user);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.True(result.Success);
        }
    }
}
