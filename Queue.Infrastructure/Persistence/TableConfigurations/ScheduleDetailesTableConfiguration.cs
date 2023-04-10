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
    public class ScheduleDetailesTableConfiguration : IEntityTypeConfiguration<ScheduleDetails>
    {
        public void Configure(EntityTypeBuilder<ScheduleDetails> builder)
        {
            builder.ToTable(nameof(ScheduleDetails));

            builder.HasKey(x => x.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.HasOne( s => s.Schedule)
                .WithMany()
                .HasForeignKey(s => s.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
