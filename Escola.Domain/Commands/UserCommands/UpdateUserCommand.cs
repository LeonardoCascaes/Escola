using Escola.Shared.Commands.Interfaces;

namespace Escola.Domain.Commands.UserCommands
{
    public class UpdateUserCommand : ICommand
    {
        public UpdateUserCommand(int id, string name, string lastName, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
