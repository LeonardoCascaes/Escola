using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Entities;

namespace Escola.Domain.Commands.ScholarityCommands
{
    public class CreateScholarityCommand : Notifiable, ICommand
    {
        public CreateScholarityCommand(string description, int userId)
        {
            Description = description;
            UserId = userId;
        }

        public string Description { get; private set; }
        public int UserId { get; private set; }


        public void Validate()
        {
            AddNotifications
                (
                    new Validation()
                    .Requires()
                    .ValidateSchooling("Description", Description)
                    .Notifications
                );
        }
    }
}
