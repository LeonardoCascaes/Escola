using Escola.Domain.Commands.ScholarityCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.ScholarityHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.Handlers.ScholarityHandlers
{
    public class UpdateScholarityHandlerTest
    {
        private readonly IScholarityRepository<Scholarity> _scholarityRepository;
        private readonly UpdateScholarityCommand _validCommand;
        private readonly UpdateScholarityCommand _invalidCommand;
        private readonly Scholarity _scholarity;

        public UpdateScholarityHandlerTest()
        {
            _scholarityRepository = Substitute.For<IScholarityRepository<Scholarity>>();
            _validCommand = new UpdateScholarityCommand(1, "Infantil");
            _invalidCommand = new UpdateScholarityCommand(1, "Tecnologo");
            _scholarity = new Scholarity("Medio", 1);
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Edicao_Da_Escolaridade_Caso_Der_Problema_Na_Validacao_Do_Command()
        {
            //Arrange
            var handler = new UpdateScholarityHandler(_scholarityRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_invalidCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Edicao_Da_Escolaridade_Caso_Nao_Possua_Escolaridade_Cadastrada()
        {
            //Arrange
            var handler = new UpdateScholarityHandler(_scholarityRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Deve_Obter_Sucesso_Para_A_Edicao_Da_Escolaridade()
        {
            //Arrange
            var handler = new UpdateScholarityHandler(_scholarityRepository);
            _scholarityRepository.Get(_validCommand.Id).Returns(_scholarity);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.True(result.Success);
        }
    }
}
