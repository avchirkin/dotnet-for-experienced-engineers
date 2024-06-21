using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelCardProject.Entities.Configurations
{
    public class CoefficientConfiguration : IEntityTypeConfiguration<Coefficient>
    {
        public void Configure(EntityTypeBuilder<Coefficient> builder)
        {
            builder.ToTable("coefficients");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(item => item.Name)
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(item => item.Value)
                .HasColumnName("value")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(item => item.DurationMinutes)
                .HasColumnName("duration_minutes")
                .HasColumnType("int");

        }
    }
}
