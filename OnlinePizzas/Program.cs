using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlinePizzas.API.Models.Pizza.Interfaces;
using OnlinePizzas.API.Models.Pizza.Models;
using OnlinePizzas.API.Persistence;
using OnlinePizzas.API.Persistence.Contexts;

namespace OnlinePizzas
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if debug
            IPizza bp = BasicPizza.TakeOrder(4, 2);
            var bpc = bp.TotalCost();
            if (bp != null)
            {
                bp = new TomatoSaucePizza(bp);
                var tsc = bp.TotalCost();
                bp = new MozarellaCheesePizza(bp);
                var mcc = bp.TotalCost();
                bp = new HamPizza(bp);
                var hc = bp.TotalCost();
            }

#endif

#if debug
            using (var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<AppDbContext>())
            {
                try
                {
                    DBInitializer.Initialize(context);
                    context.Database.EnsureCreated();
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
#endif
            var host = BuildWebHost(args);
            host.Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
           .UseStartup<Startup>()
           .Build();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
