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
    public class QueueForServiceTableConfigurarions : IEntityTypeConfiguration<QueueForService>
    {
        public void Configure(EntityTypeBuilder<QueueForService> builder)
        {
            builder.ToTable(nameof(QueueForService));
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id).ValueGeneratedOnAdd();

            builder.HasOne(v => v.Service)
                .WithMany()
                .HasForeignKey(c => c.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.Client)
                .WithMany()
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.Worker)
               .WithMany()
               .HasForeignKey(c => c.WorkerId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
