using Escola.Shared.Entities;

namespace Escola.Domain.Entities
{
    public class SchoolRecord : BaseEntity
    {
        public SchoolRecord(short year, int userId)
        {
            Year = year;
            UserId = userId;
            SchoolEvaluations = new List<SchoolEvaluation>();
        }

        public short Year { get; private set; }
        public int UserId { get; private set; }
        public User? User { get; private set; }
        public List<SchoolEvaluation> SchoolEvaluations { get; private set; }
    }
}
