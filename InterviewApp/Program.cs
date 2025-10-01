using InterviewApp.MediatRIntegration;
using InterviewApp.Models;
using InterviewApp.Services;
using InterviewApp.Validators;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;
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
                  services.AddSingleton<ITimeGreetingService, TimeGreetingService>();

                  services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
              })
            .Build();

        try
        {
            var mediator = host.Services.GetRequiredService<IMediator>();

            var timeGreeting = await mediator.Send(new GetTimeGreetingQuery());
            var userGreeting = await mediator.Send(new GreetUserCommand());

            Console.WriteLine($"{timeGreeting}! {userGreeting}");
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