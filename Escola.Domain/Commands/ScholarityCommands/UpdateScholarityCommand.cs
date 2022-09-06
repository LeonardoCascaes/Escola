using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Entities;

namespace Escola.Domain.Commands.ScholarityCommands
{
    public class UpdateScholarityCommand : Notifiable, ICommand
    {
        public UpdateScholarityCommand(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }


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
