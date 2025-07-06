using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SuperStoreApp.DataLayer;
using SuperStoreApp.Entities;
using System;
using System.Threading.Tasks;

await RunAsync();

async Task RunAsync()
{
    var host = Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((context, builder) =>
        {
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        })
        .ConfigureServices((context, services) =>
        {
            var connString = context.Configuration.GetConnectionString("SuperStoreDb");
            services.AddDbContext<SuperStoreContext>(options =>
                options.UseSqlite(connString));
        })
        .Build();

    using var scope = host.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<SuperStoreContext>();

    try
    {
        // Apply any pending migrations and create database if needed
        Console.WriteLine("Applying migrations (if any)...");
        await dbContext.Database.MigrateAsync();

        // Output some info
        var itemCount = await dbContext.Items.CountAsync();
        var clientCount = await dbContext.Clients.CountAsync();

        Console.WriteLine("✅ Database is ready!");
        Console.WriteLine($"Items count: {itemCount}");
        Console.WriteLine($"Clients count: {clientCount}");
    }
    catch (Exception ex)
    {
        Console.WriteLine("❌ Failed to initialize database.");
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
