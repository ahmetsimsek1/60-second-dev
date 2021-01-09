using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _2021_01_08_razor_pages_ajax
{
    public class Program
    {
        public static List<Person> People = new List<Person>
        {
            new Person { FirstName = "John", LastName = "Doe" },
            new Person { FirstName = "Jane", LastName = "Smith" }
        };

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
