using Escola.Shared.Commands.Interfaces;

namespace Escola.Domain.Commands.User
{
    public class CreateUserCommand : ICommand
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
            throw new NotImplementedException();
        }
    }
}
