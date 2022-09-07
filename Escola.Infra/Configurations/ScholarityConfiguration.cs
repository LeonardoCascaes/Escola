using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Configurations
{
    public class ScholarityConfiguration : IEntityTypeConfiguration<Scholarity>
    {
        public void Configure(EntityTypeBuilder<Scholarity> builder)
        {
            builder.ToTable("Scholarities");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreationDate).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.ModificationDate).HasColumnType("DateTime").IsRequired();

            builder.Property(x => x.Description).HasColumnType("Varchar(255)").IsRequired();

            builder.HasOne(s => s.User)
                .WithOne(u => u.Scholarity)
                .HasForeignKey<Scholarity>(s => s.UserId);
        }
    }
}
