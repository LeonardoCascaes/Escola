﻿namespace Escola.Shared.Entities
{
    public partial class Validation
    {
        public Validation DateGreaterThanToday(string property, DateTime testValue)
        {
            if (DateTime.UtcNow.Date < testValue.Date)
                AddNotification(new Notification(property, $"A data {testValue.Date} não pode ser maior que a data de hoje: {DateTime.UtcNow.Date}"));

            return this;
        }

        public Validation YearMustBeGreaterThan(string property, short testValue, short minYear)
        {
            if (testValue < minYear)
                AddNotification(new Notification(property, $"O ano deve ser maior que {minYear}."));

            return this;
        }
    }
}
