namespace Escola.Shared.Entities
{
    public partial class Validation
    {
        public Validation ValidateSchooling(string property, string testValue)
        {
            if (!"Infantil".ToLower().Equals(testValue.ToLower()) && !"Fundamental".ToLower().Equals(testValue.ToLower()) && !"Medio".ToLower().Equals(testValue.ToLower()) && !"Superior".ToLower().Equals(testValue.ToLower()))
                AddNotification(new Notification(property, "Escolaridade inválida, para continuar escolha uma das seguintes: Infantil, Fundamental, Medio, Superior"));

            return this;
        }
    }
}
