using Escola.Shared.Commands.Interfaces;

namespace Escola.Domain.Commands.Scholarity
{
    public class UpdateScholarityCommand : ICommand
    {
        public UpdateScholarityCommand(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }


        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
