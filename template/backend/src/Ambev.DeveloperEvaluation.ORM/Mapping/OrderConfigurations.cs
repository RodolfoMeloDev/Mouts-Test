using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn();

            builder.Property(u => u.DateOrder).IsRequired();
            builder.Property(u => u.CustomerId).IsRequired();
            builder.Property(u => u.Branch).IsRequired().HasMaxLength(100);

            builder.HasOne(p => p.Customer)
                .WithMany(u => u.Order)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.Status)
                .HasConversion<string>()
                .HasMaxLength(20);
        }
    }
}
