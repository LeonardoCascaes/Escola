using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Entities;

namespace Escola.Domain.Commands.UserCommands
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public CreateUserCommand(string name, string lastName, string email, DateTime birthDate)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public void Validate()
        {
            AddNotifications
                (
                    new Validation()
                    .Requires()
                    .HasMinLen("Name", Name, 5)
                    .HasMaxLen("Name", Name, 100)
                    .HasMinLen("LastName", LastName, 5)
                    .HasMaxLen("LastName", LastName, 100)
                    .HasAt("Email", Email)
                    .DateGreaterThanToday("BirthDate", BirthDate)
                    .Notifications
                );
        }
    }
}
