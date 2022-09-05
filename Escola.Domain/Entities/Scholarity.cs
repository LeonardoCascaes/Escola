using Escola.Shared.Entities;

namespace Escola.Domain.Entities
{
    public class Scholarity : BaseEntity
    {
        public Scholarity(string description, int userId)
        {
            Description = description;
            UserId = userId;
        }

        public string Description { get; private set; }
        public int UserId { get; private set; }
        public User? User { get; private set; }
    }
}
