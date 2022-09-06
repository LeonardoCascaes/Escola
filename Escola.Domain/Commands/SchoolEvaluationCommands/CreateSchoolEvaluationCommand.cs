using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Entities;

namespace Escola.Domain.Commands.SchoolEvaluationCommands
{
    public class CreateSchoolEvaluationCommand : Notifiable, ICommand
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
            AddNotifications
                (
                    new Validation()
                        .Requires()
                        .HasMinLen("Matter", Matter, 3)
                        .HasMaxLen("Matter", Matter, 100)
                        .Notifications
                );
        }
    }
}
