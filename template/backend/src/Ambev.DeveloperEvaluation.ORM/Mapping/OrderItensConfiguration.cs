using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class OrderItensConfiguration : IEntityTypeConfiguration<OrderItens>
    {
        public void Configure(EntityTypeBuilder<OrderItens> builder)
        {
            builder.ToTable("OrderItens");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn();

            builder.Property(u => u.OrderId).IsRequired();
            builder.Property(u => u.ProductId).IsRequired();
            builder.Property(u => u.Quantities).IsRequired();
            builder.Property(u => u.UnitPrice).IsRequired();
            builder.Property(u => u.TotalPrice).IsRequired();

            builder.HasOne(p => p.Order)
                   .WithMany(u => u.Itens)
                   .HasForeignKey(o => o.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Product)
                   .WithMany(u => u.OrderItens)
                   .HasForeignKey(o =>o.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
