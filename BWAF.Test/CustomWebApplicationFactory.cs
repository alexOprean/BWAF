namespace BWAF.Test
{
    using BWAF.Api;
    using BWAF.Data;
    using BWAF.Data.Provisioning;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;

    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private readonly string TestDataConnectionString = "TestDataConnection";
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault
                   (d => d.ServiceType == typeof(DbContextOptions<Context>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }
                var scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
                using (var serviceScope = scopeFactory.CreateScope())
                {
                    var provider = serviceScope.ServiceProvider;
                    IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
                    IWebHostEnvironment env = provider.GetRequiredService<IWebHostEnvironment>();

                    if (env.IsDevelopment())
                    {
                        services.AddDbContext<Context>((_, context) => context.UseSqlServer(configuration.GetConnectionString(TestDataConnectionString)));
                    }
                    else
                    {
                        services.AddDbContext<Context>((_, context) => context.UseInMemoryDatabase(configuration.GetConnectionString(TestDataConnectionString)));
                    }
                };

                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();

                var dbContext = scope.ServiceProvider.GetRequiredService<Context>();

                dbContext.Database.EnsureCreated();
                DbInitializer.Initialize(dbContext);
            });
        }

        protected override void Dispose(bool disposing)
        {
            var scopeFactory = Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<Context>();
                context.Database.EnsureDeleted();
            }
        }
    }
}
