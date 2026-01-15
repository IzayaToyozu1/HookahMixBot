using HookahMixBot.Application.Commands;
using HookahMixBot.Core.Interfaces;
using HookahMixBot.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using HookahMixBot.Telegram.Handlers;


namespace HookahMixBot.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<ITelegramBotClient>(sp => new TelegramBotClient(context.Configuration["BotToken"]));
                    
                    services.AddScoped<ITelegramUpdateHandler, CommandHandler>();
                    services.AddScoped<AddMixCommandHandler>();
                    services.AddSingleton<IMixRepository, MixRepository>();

                    services.AddHostedService<BotBackgroundService>();
                });
    }
}