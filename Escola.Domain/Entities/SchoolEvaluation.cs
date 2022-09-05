using Escola.Shared.Entities;

namespace Escola.Domain.Entities
{
    public class SchoolEvaluation : BaseEntity
    {
        public SchoolEvaluation(string matter, float grade, int schoolRecordId)
        {
            Matter = matter;
            Grade = grade;
            SchoolRecordId = schoolRecordId;
        }

        public string Matter { get; private set; }
        public float Grade { get; private set; }
        public int SchoolRecordId { get; private set; }
        public SchoolRecord? SchoolRecord { get; private set; }
    }
}
