using Escola.Shared.Commands.Interfaces;

namespace Escola.Domain.Commands.SchoolEvaluationCommands
{
    public class UpdateSchoolEvaluationCommand : ICommand
    {
        public UpdateSchoolEvaluationCommand(int id, string matter, float grade)
        {
            Id = id;
            Matter = matter;
            Grade = grade;
        }

        public int Id { get; private set; }
        public string Matter { get; private set; }
        public float Grade { get; private set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
