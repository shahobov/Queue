using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Infrastructure.Persistence.TableConfigurations
{
    public class ServiceTableConfigurations : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable(nameof(Service));
            builder.Property(t => t.Id).UseIdentityColumn().HasColumnType("bigint").ValueGeneratedOnAdd();
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(v => v.Category)
               .WithMany()
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
