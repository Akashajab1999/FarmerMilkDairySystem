using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartDairy.Domain.Entities;

namespace SmartDairy.Persistence.Configurations;

public class FarmerConfiguration : IEntityTypeConfiguration<Farmer>
{
    public void Configure(EntityTypeBuilder<Farmer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FarmerCode)
               .HasMaxLength(20)
               .IsRequired();

        builder.Property(x => x.FirstName)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.LastName)
               .HasMaxLength(100);

        builder.Property(x => x.MobileNumber)
               .HasMaxLength(15)
               .IsRequired();

        builder.Property(x => x.Address)
               .HasMaxLength(300);

        builder.Property(x => x.Village)
               .HasMaxLength(100);

        builder.Property(x => x.AadhaarNumber)
               .HasMaxLength(20);
    }
}