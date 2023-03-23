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
    public class WorkerSkillsTableConfigurations : IEntityTypeConfiguration<WorkerSkills>
    {
        public void Configure(EntityTypeBuilder<WorkerSkills> builder)
        {
            builder.ToTable(nameof(WorkerSkills));
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id).ValueGeneratedOnAdd();

            builder.HasOne(v => v.Services)
                .WithMany()
                .HasForeignKey(c => c.ServiceID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(w => w.Workers)
                   .WithMany()
                   .HasForeignKey(w => w.WorkerID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}
