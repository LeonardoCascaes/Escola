using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.Configurations
{
    public class SchoolEvaluationConfiguration : IEntityTypeConfiguration<SchoolEvaluation>
    {
        public void Configure(EntityTypeBuilder<SchoolEvaluation> builder)
        {
            builder.ToTable("SchoolEvaluations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreationDate).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.ModificationDate).HasColumnType("DateTime").IsRequired();

            builder.Property(x => x.Matter).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(x => x.Grade).HasColumnType("Float(3,2)").IsRequired();

            builder.HasOne(se => se.SchoolRecord)
                .WithMany(sr => sr.SchoolEvaluations)
                .HasForeignKey(se => se.SchoolRecordId);
        }
    }
}
