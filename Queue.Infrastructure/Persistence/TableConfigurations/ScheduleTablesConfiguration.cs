using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Infrastructure.Persistence.TableConfigurations
{
    public class ScheduleTablesConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable(nameof(Schedule));
            builder.Property(t => t.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.HasKey(t => t.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.HasOne(v => v.Worker)
                .WithMany()
                .HasForeignKey(c => c.WorkerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
