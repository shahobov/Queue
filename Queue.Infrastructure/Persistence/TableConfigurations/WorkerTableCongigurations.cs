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
    public class WorkerTableCongigurations : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable(nameof(Worker));
            builder.Property(t => t.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();

            builder.HasOne(v => v.Job)
                .WithMany()
                .HasForeignKey(c => c.JobId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
