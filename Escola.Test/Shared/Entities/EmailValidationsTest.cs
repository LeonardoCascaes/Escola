using Escola.Shared.Entities;
using Xunit;

namespace Escola.Test.Shared.Entities
{
    public class EmailValidationsTest
    {
        [Fact]
        public void Nao_Deve_Retornar_Notificacao_Caso_O_Valor_Teste_Possua_Arroba()
        {
            //Arrange
            var testValue = "test@test.com";
            var validation = new Validation().Requires().HasAt("testValue", testValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Caso_O_Valor_Teste_Nao_Possua_Arroba()
        {
            //Arrange
            var testValue = "test.com";
            var validation = new Validation().Requires().HasAt("testValue", testValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(1, notifications.Count);
            Assert.False(validation.IsValid());
        }
    }
}
