using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Queue.Infrastructure.Persistence.Database;
using System;

namespace Queue.API
{
    public static class DependencyInjection
    {
        public static void MigrateDatabase(this WebApplication application)
        {
            using var scope = application.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var db = services.GetRequiredService<EFContext>();
                db.Database.Migrate();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
