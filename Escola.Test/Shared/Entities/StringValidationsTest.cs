using Escola.Shared.Entities;
using Xunit;

namespace Escola.Test.Shared.Entities
{
    public class StringValidationsTest
    {
        private const int minLen = 5;
        private const int maxLen = 10;

        [Fact]
        public void Nao_Deve_Retornar_Notificacoes_Quando_A_Quantidade_De_Caracteres_Do_Valor_Teste_For_Maior_Que_O_Minimo_Permitido()
        {
            //Arrange
            var testValue = "Leonardo";
            var validation = new Validation().Requires().HasMinLen("testValue", testValue, minLen);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void Deve_Retornar_Notificacoes_Quando_A_Quantidade_De_Caracteres_Do_Valor_Teste_For_Menor_Que_O_Minimo_Permitido()
        {
            //Arrange
            var testValue = "Leo";
            var validation = new Validation().Requires().HasMinLen("testValue", testValue, minLen);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(1, notifications.Count);
            Assert.False(validation.IsValid());
        }

        [Fact]
        public void Nao_Deve_Retornar_Notificacoes_Quando_A_Quantidade_De_Caracteres_Do_Valor_Teste_For_Menor_Que_O_Maximo_Permitido()
        {
            //Arrange
            var testValue = "Iguana";
            var validation = new Validation().Requires().HasMaxLen("testValue", testValue, maxLen);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void Deve_Retornar_Notificacoes_Quando_A_Quantidade_De_Caracteres_Do_Valor_Teste_For_Maior_Que_O_Maximo_Permitido()
        {
            //Arrange
            var testValue = "Iguana Colorida";
            var validation = new Validation().Requires().HasMaxLen("testValue", testValue, maxLen);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(1, notifications.Count);
            Assert.False(validation.IsValid());
        }
    }
}
