using Escola.Shared.Commands.Interfaces;

namespace Escola.Domain.Commands.Scholarity
{
    public class CreateScholarityCommand : ICommand
    {
        public CreateScholarityCommand(string description, int userId)
        {
            Description = description;
            UserId = userId;
        }

        public string Description { get; private set; }
        public int UserId { get; private set; }


        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
