using Microsoft.EntityFrameworkCore;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Infrastructure.DBContext
{
    public class AplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Client>().ToTable(b => b.IsMemoryOptimized());
        }

    }
}
