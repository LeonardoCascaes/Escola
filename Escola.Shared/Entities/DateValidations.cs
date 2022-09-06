namespace Escola.Shared.Entities
{
    public partial class Validation
    {
        public Validation DateGreaterThanToday(string property, DateTime testValue)
        {
            if (DateTime.UtcNow.Date < testValue.Date)
                AddNotification(new Notification(property, $"A data {testValue.Date} não pode ser maior que a data de hoje: {DateTime.UtcNow.Date}"));

            return this;
        }
    }
}
