using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TravelCardProject.Entities.Configurations
{
    public class TerminalConfiguration : IEntityTypeConfiguration<Terminal>
    {
        public void Configure(EntityTypeBuilder<Terminal> builder)
        {
            builder.ToTable("terminals");

            builder.HasKey(item => item.Id);

            builder.Property(item => item.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(item => item.TransportType)
                .HasColumnName("transport_type")
                .HasColumnType("int")
                .IsRequired();

            builder.HasMany(item => item.Trips)
                .WithOne(item => item.Terminal)
                .HasForeignKey(item => item.TerminalId);
        }
    }
}
