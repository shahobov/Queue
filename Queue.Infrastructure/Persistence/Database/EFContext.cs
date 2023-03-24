﻿using Microsoft.EntityFrameworkCore;
using Queue.Domain.Abstract;
using Queue.Domain.Model;
using Queue.Infrastructure.Persistencee.TableConfigurations;
using Client = MySqlX.XDevAPI.Client;

namespace Queue.Infrastructure.Persistence.Database
{
    public class EFContext : DbContext
    {
       
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<EntityBase>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientTablesConfigurations).Assembly);
        }
    }
}
