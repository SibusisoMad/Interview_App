using InterviewApp.Models;
using InterviewApp.Services;
using InterviewApp.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
              .ConfigureServices((context, services) => {
                  services.Configure<GreetingOptions>(context.Configuration.GetSection("Greeting"));
                  services.AddSingleton<IValidateOptions<GreetingOptions>, GreetingOptionsValidator>();
                  services.AddTransient<IGreetingService, GreetingService>();
              })
            .Build();

        try
        {
            var greetingService = host.Services.GetRequiredService<IGreetingService>();
            var message = greetingService.GetGreetingMessage();
            Console.WriteLine(message);
        }
        catch (OptionsValidationException ex)
        {
            Console.WriteLine("Configuration validation failed:");
            foreach (var failure in ex.Failures)
            {
                Console.WriteLine($" - {failure}");
            }
            Environment.Exit(1);
        }

        await host.RunAsync();
    }

}