using Escola.Domain.Commands.SchoolRecordCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.SchoolRecordHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Escola.Test.Domain.Handlers.SchoolRecordHandlers
{
    public class CreateSchoolRecordHandlerTest
    {
        private readonly ISchoolRecordRepository<SchoolRecord> _SchoolRecordRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly CreateSchoolRecordCommand _validCommand;
        private readonly CreateSchoolRecordCommand _invalidCommand;
        private readonly SchoolRecord _schoolRecord;
        private readonly User _user;

        public CreateSchoolRecordHandlerTest()
        {
            _SchoolRecordRepository = Substitute.For<ISchoolRecordRepository<SchoolRecord>>();
            _userRepository = Substitute.For<IUserRepository<User>>();
            _validCommand = new CreateSchoolRecordCommand(2010, 1);
            _invalidCommand = new CreateSchoolRecordCommand(1800, 3);
            _schoolRecord = new SchoolRecord(2010, 1);
            _user = new User("Rafael", "AlgumaCoisa", "Rafal@test.com", DateTime.UtcNow.AddYears(-15));
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Criacao_Do_Historico_Escolar_Caso_Der_Problema_Na_Validacao_Do_Command()
        {
            //Arrange
            var handler = new CreateSchoolRecordhandler(_SchoolRecordRepository ,_userRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_invalidCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Criacao_Do_Historico_Escolar_Caso_Nao_Encontrar_O_Usuario()
        {
            //Arrange
            var handler = new CreateSchoolRecordhandler(_SchoolRecordRepository, _userRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_A_Criacao_Do_Historico_Escolar_Caso_O_Usuario_Ja_Tenha_Um_Cadastrado()
        {
            //Arrange
            var handler = new CreateSchoolRecordhandler(_SchoolRecordRepository, _userRepository);
            _userRepository.Get(_validCommand.UserId).Returns(_user);
            _SchoolRecordRepository.GetSchoolRecordByUserId(_validCommand.UserId).Returns(_schoolRecord);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Deve_Obter_Sucesso_Para_A_Criacao_Do_Historico_Escolar()
        {
            //Arrange
            var handler = new CreateSchoolRecordhandler(_SchoolRecordRepository, _userRepository);
            _userRepository.Get(_validCommand.UserId).Returns(_user);

            //Act
            var result = (GenericCommandResult)await handler.Handle(_validCommand);

            //Assert
            Assert.True(result.Success);
        }
    }
}
