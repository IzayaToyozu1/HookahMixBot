using HookahMixBot.Telegram.Handlers;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

namespace HookahMixBot.Console;

public class BotBackgroundService : BackgroundService
{
    private readonly ITelegramBotClient _botClient;
    private readonly ITelegramUpdateHandler _updateHandler;

    public BotBackgroundService(ITelegramBotClient botClient, ITelegramUpdateHandler updateHandler)
    {
        _botClient = botClient;
        _updateHandler = updateHandler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var offset = 0;

        while (!stoppingToken.IsCancellationRequested)
        {
            var updates = await _botClient.GetUpdates(offset, cancellationToken: stoppingToken);

            foreach (var update in updates)
            {
                await _updateHandler.HandleUpdateAsync(update);
                offset = update.Id + 1;
            }
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}