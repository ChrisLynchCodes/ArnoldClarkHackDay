using Display.Interfaces;
using Display.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.IO;
using Serilog;
using GameLogic.Interfaces;
using GameLogic.Concretes;

namespace RockPaperScissorsLizardSpock
{
    internal class Program
    {
        /// <summary>
        /// setup logging and dependency injection - run the app
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            //setup logging
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.File("C:\\Users\\Chris\\Desktop\\logs.txt")
                .CreateLogger();
              //.WriteTo.Console()
            Log.Logger.Information("LOG: Application starting");

            //setup dependency injection
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IApp, App>();
                    services.AddTransient<IDisplay, ConsoleDisplay>();
                    services.AddTransient<IGame, Game>();
                    services.AddTransient<IPlayer, Player>();
                    services.AddTransient<IMove, Move>();
                })
                .UseSerilog()
                .Build();

            //App is a new entry point of sorts
            var appService = ActivatorUtilities.CreateInstance<App>(host.Services);
            appService.Run();

            Log.Logger.Information("LOG: Application ending");
        }
        /// <summary>
        /// get logging settings & other settings from appsettings.json
        /// </summary>
        /// <param name="configurationBuilder">used to build key/value-based configuration settings</param>
        private static void BuildConfig(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
