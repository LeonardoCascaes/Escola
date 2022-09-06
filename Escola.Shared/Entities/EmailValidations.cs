namespace Escola.Shared.Entities
{
    public partial class Validation
    {
        public Validation HasAt(string property, string testValue)
        {
            if (!testValue.Contains('@'))
                AddNotification(new Notification(property, $"{property} não é um email válido."));

            return this;
        }
    }
}
