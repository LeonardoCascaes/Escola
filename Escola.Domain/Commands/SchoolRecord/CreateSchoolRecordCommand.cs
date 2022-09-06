using Escola.Shared.Commands.Interfaces;

namespace Escola.Domain.Commands.SchoolRecord
{
    public class CreateSchoolRecordCommand : ICommand
    {
        public CreateSchoolRecordCommand(short year, int userId)
        {
            Year = year;
            UserId = userId;
        }

        public short Year { get; private set; }
        public int UserId { get; private set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
