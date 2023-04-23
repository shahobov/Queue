using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Infrastructure.Persistence.TableConfigurations
{
    public class OrderTableConfigurarions : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.Property(t => t.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id).ValueGeneratedOnAdd();

            builder.HasMany(v => v.OrderDetils)
                .WithOne(o => o.Order)
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
