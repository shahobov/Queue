using Microsoft.EntityFrameworkCore;
using Queue.Domain.Abstract;
using Queue.Infrastructure.Persistencee.TableConfigurations;

namespace Queue.Infrastructure.Persistence.Database
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<EntityBase>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientTablesConfigurations).Assembly);
        }
    }
}
