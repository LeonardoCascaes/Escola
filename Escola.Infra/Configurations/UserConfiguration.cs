using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreationDate).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.ModificationDate).HasColumnType("DateTime").IsRequired();

            builder.Property(x => x.Name).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.LastName).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("Varchar(255)").IsRequired();
            builder.Property(x => x.BirthDate).HasColumnType("Date").IsRequired();
        }
    }
}
