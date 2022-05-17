// See https://aka.ms/new-console-template for more information

using Hera.Infrastructure.Persistence;
using Hera.Migration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Applying migrations");
var webHost = new WebHostBuilder()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .UseStartup<ConsoleStartup>()
    .Build();
using (var context = (HeraDbContext)webHost.Services.GetService(typeof(HeraDbContext)))
{
    context.Database.Migrate();
}
Console.WriteLine("Done");


