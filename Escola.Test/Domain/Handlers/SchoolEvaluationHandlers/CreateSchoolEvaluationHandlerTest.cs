using Escola.Domain.Commands.SchoolEvaluationCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.SchoolEvaluationHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Escola.Test.Domain.Handlers.SchoolEvaluationHandlers
{
    public class CreateSchoolEvaluationHandlerTest
    {
        private readonly ISchoolRecordRepository<SchoolRecord> _SchoolRecordRepository;
        private readonly ISchoolEvaluationRepository<SchoolEvaluation> _schoolEvaluationRepository;
        private readonly CreateSchoolEvaluationCommand _validCommand;
        private readonly CreateSchoolEvaluationCommand _invalidCommand;
        private readonly SchoolRecord _schoolRecord;

        public CreateSchoolEvaluationHandlerTest()
        {
            _SchoolRecordRepository = Substitute.For<ISchoolRecordRepository<SchoolRecord>>();
            _schoolEvaluationRepository = Substitute.For<ISchoolEvaluationRepository<SchoolEvaluation>>();
            _validCommand = new CreateSchoolEvaluationCommand("Portugues", 10, 1);
            _invalidCommand = new CreateSchoolEvaluationCommand("AA", 5, 1);
            _schoolRecord = new SchoolRecord(2010, 1);
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Criacao_Da_Avaliacao_Caso_Der_Problema_Na_Validacao_Do_Command()
        {
            //Arrange
            var handler = new CreateSchoolEvaluationHandler(_SchoolRecordRepository, _schoolEvaluationRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_invalidCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Criacao_Da_Avaliacao_Caso_Nao_Possuir_Historico_Escolar_Cadastrado()
        {
            //Arrange
            var handler = new CreateSchoolEvaluationHandler(_SchoolRecordRepository, _schoolEvaluationRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Deve_Obter_Sucesso_Para_A_Criacao_Da_Avaliacao()
        {
            //Arrange
            var handler = new CreateSchoolEvaluationHandler(_SchoolRecordRepository, _schoolEvaluationRepository);
            _SchoolRecordRepository.Get(_validCommand.SchoolRecordId).Returns(_schoolRecord);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.True(result.Success);
        }
    }
}
