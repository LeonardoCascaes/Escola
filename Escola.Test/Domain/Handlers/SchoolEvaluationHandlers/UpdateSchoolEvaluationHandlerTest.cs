using Escola.Domain.Commands.SchoolEvaluationCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.SchoolEvaluationHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.Handlers.SchoolEvaluationHandlers
{
    public class UpdateSchoolEvaluationHandlerTest
    {
        private readonly ISchoolEvaluationRepository<SchoolEvaluation> _schoolEvaluationRepository;
        private readonly UpdateSchoolEvaluationCommand _validCommand;
        private readonly UpdateSchoolEvaluationCommand _invalidCommand;
        private readonly SchoolEvaluation _schoolEvaluation;

        public UpdateSchoolEvaluationHandlerTest()
        {
            _schoolEvaluationRepository = Substitute.For<ISchoolEvaluationRepository<SchoolEvaluation>>();
            _validCommand = new UpdateSchoolEvaluationCommand(1, "Portugues", 10);
            _invalidCommand = new UpdateSchoolEvaluationCommand(1, "AA", 5);
            _schoolEvaluation = new SchoolEvaluation("Matematica", 5, 1);
        }


        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_Editar_A_Avaliacao_Caso_Der_Problema_Na_Validacao_Do_Command()
        {
            //Arrange
            var handler = new UpdateSchoolEvaluationHandler(_schoolEvaluationRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_invalidCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_Editar_A_Avaliacao_Caso_Nao_Possuir_A_Avaliacao_Cadastrada()
        {
            //Arrange
            var handler = new UpdateSchoolEvaluationHandler(_schoolEvaluationRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Deve_Obter_Sucesso_Para_Editar_A_Avaliacao()
        {
            //Arrange
            var handler = new UpdateSchoolEvaluationHandler(_schoolEvaluationRepository);
            _schoolEvaluationRepository.Get(_validCommand.Id).Returns(_schoolEvaluation);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.True(result.Success);
        }
    }
}
