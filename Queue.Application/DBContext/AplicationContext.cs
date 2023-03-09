using Microsoft.EntityFrameworkCore;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.DBContext
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }

 
    }
}
