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
    public class OrderDetilsTableConfigurarions : IEntityTypeConfiguration<OrderDetils>
    {
        public void Configure(EntityTypeBuilder<OrderDetils> builder)
        {
            builder.ToTable(nameof(OrderDetils));
            builder.Property(t => t.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();

            builder.HasOne(v => v.Service)
                .WithMany()
                .HasForeignKey(c => c.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.Order)
                .WithMany()
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
