using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Entities;

namespace Escola.Domain.Commands.SchoolRecordCommands
{
    public class CreateSchoolRecordCommand : Notifiable, ICommand
    {
        public CreateSchoolRecordCommand(short year, int userId)
        {
            Year = year;
            UserId = userId;
        }

        public short Year { get; private set; }
        public int UserId { get; private set; }

        public void Validate()
        {
            AddNotifications
                (
                    new Validation()
                        .Requires()
                        .YearMustBeGreaterThan("Year", Year, 2015)
                        .Notifications
                );
        }
    }
}
