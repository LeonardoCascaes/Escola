namespace Escola.Shared.ValueObjects
{
    public class FullName
    {
        public FullName(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
    }
}
