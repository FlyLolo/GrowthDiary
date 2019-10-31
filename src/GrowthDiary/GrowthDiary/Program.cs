using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GrowthDiary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://*:8081").UseStartup<Startup>();
                });
    }
}
