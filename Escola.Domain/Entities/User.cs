using Escola.Shared.Entities;
using Escola.Shared.ValueObjects;

namespace Escola.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(FullName fullName, string email, DateTime birthDate, int scholarityId = 0, int schoolRecordId = 0)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            ScholarityId = scholarityId;
            SchoolRecordId = schoolRecordId;
        }

        public FullName FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int ScholarityId { get; private set; }
        public Scholarity? Scholarity { get; private set; }
        public int SchoolRecordId { get; private set; }
        public SchoolRecord? SchoolRecord { get; private set; }
    }
}
