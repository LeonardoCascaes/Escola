using Escola.Shared.Entities;
using Xunit;

namespace Escola.Test.Shared.Entities
{
    public class DateValidationsTest
    {
        private const int minYear = 2000;

        [Fact]
        public void Nao_Deve_Retornar_Notificacao_Caso_A_Data_Do_Valor_Teste_Seja_Menor_Que_A_Data_De_Hoje()
        {
            //Arrange
            var testValue = DateTime.UtcNow.Date.AddYears(-10);
            var validation = new Validation().Requires().DateGreaterThanToday("testValue", testValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Caso_A_Data_Do_Valor_Teste_Seja_Maior_Que_A_Data_De_Hoje()
        {
            //Arrange
            var testValue = DateTime.UtcNow.Date.AddDays(5);
            var validation = new Validation().Requires().DateGreaterThanToday("testValue", testValue);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(1, notifications.Count);
            Assert.False(validation.IsValid());
        }

        [Fact]
        public void Nao_Deve_Retornar_Notificacao_Caso_O_Ano_Do_Valor_Teste_Seja_Maior_Que_O_Ano_Minimo()
        {
            //Arrange
            short testValue = 2010;
            var validation = new Validation().Requires().YearMustBeGreaterThan("testValue", testValue, minYear);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(0, notifications.Count);
            Assert.True(validation.IsValid());
        }

        [Fact]
        public void Deve_Retornar_Notificacao_Caso_O_Ano_Do_Valor_Teste_Seja_Menor_Que_O_Ano_Minimo()
        {
            //Arrange
            short testValue = 1950;
            var validation = new Validation().Requires().YearMustBeGreaterThan("testValue", testValue, minYear);

            //Act
            var notifications = validation.Notifications;

            //Assert
            Assert.Equal(1, notifications.Count);
            Assert.False(validation.IsValid());
        }
    }
}
