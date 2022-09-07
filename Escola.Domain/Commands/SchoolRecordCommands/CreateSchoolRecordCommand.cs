using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Entities;

namespace Escola.Domain.Commands.SchoolRecordCommands
{
    public class CreateSchoolRecordCommand : Notifiable, ICommand
    {
        public CreateSchoolRecordCommand(short yearOfCompletion, int userId)
        {
            YearOfCompletion = yearOfCompletion;
            UserId = userId;
        }

        public short YearOfCompletion { get; private set; }
        public int UserId { get; private set; }

        public void Validate()
        {
            AddNotifications
                (
                    new Validation()
                        .Requires()
                        .YearMustBeGreaterThan("YearOfCompletion", YearOfCompletion, 1990)
                        .Notifications
                );
        }
    }
}
