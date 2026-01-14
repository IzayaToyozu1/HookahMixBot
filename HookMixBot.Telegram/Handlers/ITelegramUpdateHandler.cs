using Telegram.Bot.Types;

namespace HookMixBot.Telegram.Handlers;

public interface ITelegramUpdateHandler
{
    Task HandleUpdateAsync(Update update);
}