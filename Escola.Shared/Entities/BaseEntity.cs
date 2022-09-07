namespace Escola.Shared.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ModificationDate { get; private set; }

        protected BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
            ModificationDate = DateTime.UtcNow;
        }

        public void ChangeModificationDate()
        {
            ModificationDate = DateTime.UtcNow;
        }
    }
}
