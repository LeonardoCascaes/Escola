using Escola.Shared.Entities;

namespace Escola.Domain.Entities
{
    public class SchoolRecord : BaseEntity
    {
        public SchoolRecord(int userId)
        {
            UserId = userId;
            SchoolEvaluations = new List<SchoolEvaluation>();
        }

        public int UserId { get; private set; }
        public User? User { get; private set; }
        public List<SchoolEvaluation> SchoolEvaluations { get; private set; }
    }
}
