namespace Escola.Shared.Entities
{
    public partial class Validation
    {
        public Validation HasMinLen(string property, string testValue, int minLenght)
        {
            if (testValue.Length < minLenght)
                AddNotification(new Notification(property, $"{property} não pode conter menos que {minLenght} caracteres."));

            return this;
        }

        public Validation HasMaxLen(string property, string testValue, int maxLenght)
        {
            if (testValue.Length > maxLenght)
                AddNotification(new Notification(property, $"{property} não pode conter mais que {maxLenght} caracteres."));

            return this;
        }
    }
}
