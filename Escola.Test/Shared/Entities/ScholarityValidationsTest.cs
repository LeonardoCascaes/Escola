using Escola.Shared.Entities;
using Xunit;

namespace Escola.Test.Shared.Entities
{
    public class ScholarityValidationsTest
    {
        [Fact]
        public void Nao_Deve_Retornar_Notificacao_Com_O_Valor_Teste_Sendo_Infantil()
        {
            //Arrange
            var testValue = "inFanTil";
            var validation = new Validation().Requires().ValidateSchooling("testValue", testValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void Nao_Deve_Retornar_Notificacao_Com_O_Valor_Teste_Sendo_Fundamental()
        {
            //Arrange
            var testValue = "fundamental";
            var validation = new Validation().Requires().ValidateSchooling("testValue", testValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void Nao_Deve_Retornar_Notificacao_Com_O_Valor_Teste_Sendo_Medio()
        {
            //Arrange
            var testValue = "MEDIO";
            var validation = new Validation().Requires().ValidateSchooling("testValue", testValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void Nao_Deve_Retornar_Notificacao_Com_O_Valor_Teste_Sendo_Superior()
        {
            //Arrange
            var testValue = "SuPeriOR";
            var validation = new Validation().Requires().ValidateSchooling("testValue", testValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Com_O_Valor_Teste_Sendo_Diferente_De_Infantil_Fundamental_Medio_Ou_Superior()
        {
            //Arrange
            var testValue = "tecnico";
            var validation = new Validation().Requires().ValidateSchooling("testValue", testValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(1, notifications.Count);
            Assert.False(validation.IsValid());
        }
    }
}
