using Escola.Shared.Entities;

namespace Escola.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string lastName, string email, DateTime birthDate)
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
        public Scholarity? Scholarity { get; private set; }
        public SchoolRecord? SchoolRecord { get; private set; }

        public void ChangeName(string newName)
        {
            Name = newName;
        }

        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
        }

        public void ChangeBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }
    }
}
