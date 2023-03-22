using Microsoft.EntityFrameworkCore;
using Queue.Domain.Model;
using Queue.Infrastructure.Persistencee.TableConfigurations;

namespace Queue.Infrastructure.Persistence.Database
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)  { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<EntityBase>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientTablesConfigurations).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Queue;Trusted_Connection=True;");

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Queue;Username=postgres;Password=123");
        }
    }
}
