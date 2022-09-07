using Escola.Domain.Entities;
using Escola.Domain.Handlers.ScholarityHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Shared.Commands;
using NSubstitute;
using Xunit;

namespace Escola.Test.Domain.Handlers.ScholarityHandlers
{
    public class DeleteScholarityHandlerTest
    {
        private readonly IScholarityRepository<Scholarity> _scholarityRepository;
        private readonly Scholarity _scholarity;
        private const int scholarityId = 10;

        public DeleteScholarityHandlerTest()
        {
            _scholarityRepository = Substitute.For<IScholarityRepository<Scholarity>>();
            _scholarity = new Scholarity("Medio", 10);
        }


        [Fact]
        public async Task Nao_Deve_Obter_Sucesso_Para_Deletar_A_Escolaridade_Caso_Nao_Possua_Escolaridade_Cadastrada()
        {
            //Arrange
            var handler = new DeleteScholarityHandler(_scholarityRepository);

            //Act
            var result = (GenericCommandResult)await handler.Handle(scholarityId);

            //Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Deve_Obter_Sucesso_Para_Deletar_A_Escolaridade()
        {
            //Arrange
            var handler = new DeleteScholarityHandler(_scholarityRepository);
            _scholarityRepository.Get(scholarityId).Returns(_scholarity);

            //Act
            var result = (GenericCommandResult)await handler.Handle(scholarityId);

            //Assert
            Assert.True(result.Success);
        }
    }
}
