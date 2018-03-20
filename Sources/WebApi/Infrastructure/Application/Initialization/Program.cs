using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Mmu.Mls2.WebApi.Infrastructure.Application.Initialization
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}