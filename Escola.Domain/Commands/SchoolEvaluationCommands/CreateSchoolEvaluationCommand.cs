using Escola.Shared.Commands.Interfaces;

namespace Escola.Domain.Commands.SchoolEvaluationCommands
{
    public class CreateSchoolEvaluationCommand : ICommand
    {
        public CreateSchoolEvaluationCommand(string matter, float grade, int schoolRecordId)
        {
            Matter = matter;
            Grade = grade;
            SchoolRecordId = schoolRecordId;
        }

        public string Matter { get; private set; }
        public float Grade { get; private set; }
        public int SchoolRecordId { get; private set; }


        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
