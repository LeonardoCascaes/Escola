using Escola.Shared.Commands.Interfaces;
using Escola.Shared.Entities;

namespace Escola.Domain.Commands.SchoolEvaluationCommands
{
    public class UpdateSchoolEvaluationCommand : Notifiable, ICommand
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
