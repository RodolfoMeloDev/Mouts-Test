using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn();

            builder.Property(u => u.CustomerName).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Birthday).IsRequired();
            builder.Property(u => u.Address).IsRequired().HasMaxLength(250);
            builder.Property(u => u.NumberAdrress).HasMaxLength(50);
            builder.Property(u => u.Complement).HasMaxLength(1000);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Phone).HasMaxLength(20);

            builder.Property(u => u.Status)
                .HasConversion<string>()
                .HasMaxLength(20);
        }
    }
}
