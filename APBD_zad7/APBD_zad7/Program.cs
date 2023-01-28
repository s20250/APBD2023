using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_zad7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            void Configure(IWebHostBuilder webBuilder)
            {
                webBuilder.UseStartup<Startup>();
            }

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(Configure);
        }
    }
}