using Telegram.Bot.Types;

namespace HookahMixBot.Telegram.Handlers;

public interface ITelegramUpdateHandler
{
    Task HandleUpdateAsync(Update update);
}