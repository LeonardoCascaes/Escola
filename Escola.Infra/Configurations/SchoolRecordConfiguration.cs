using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Configurations
{
    public class SchoolRecordConfiguration : IEntityTypeConfiguration<SchoolRecord>
    {
        public void Configure(EntityTypeBuilder<SchoolRecord> builder)
        {
            builder.ToTable("SchoolRecords");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreationDate).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.ModificationDate).HasColumnType("DateTime").IsRequired();

            builder.Property(x => x.Year).HasColumnType("SmallInt").IsRequired();

            builder.HasOne(s => s.User)
                .WithOne(u => u.SchoolRecord)
                .HasForeignKey<SchoolRecord>(s => s.UserId);

        }
    }
}
