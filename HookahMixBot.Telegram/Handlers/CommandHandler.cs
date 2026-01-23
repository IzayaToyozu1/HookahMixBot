using HookahMixBot.Application.Commands;
using HookahMixBot.Application.Service;
using HookahMixBot.Core.Entities;
using HookMixBot.Telegram.Keyboards;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HookahMixBot.Telegram.Handlers;

public class CommandHandler : ITelegramUpdateHandler
{
    private readonly Dictionary<string, Func<Message, UserBot, Task>> _commands;
    private readonly IUserService _userService;
    private readonly AddMixCommandHandler _addMixHandler;
    private readonly ITelegramBotClient _botClient;

    public CommandHandler(AddMixCommandHandler addMixHandler)
    {
        _addMixHandler = addMixHandler;

        _commands = new Dictionary<string, Func<Message, UserBot, Task>>
        {
            { "/start", HandleStartCommand },
            { "/prifile", HandleProfileCommand },
            { "/my_mixes", HandleMyMixesCommand },
            { "/favorites", HandleFavoritesCommand },
            { "/addmix", HandleAddMixCommand },
            { "/search", HandleSearchCommand },
            { "/top", HandleTopMixesCommand },
        };
    }

    public async Task HandleUpdateAsync(Update update)
    {
        UserBot userBot = await _userService.GetOrCreateUserAsync(
            telegramId: update.Message.From.Id,
            name: update.Message.From.Username);
        if (update.Message?.Text != null)
        {
            var command = update.Message.Text.Split(' ')[0].ToLower();

            if (_commands.ContainsKey(command))
            {
                await _commands[command](update.Message, userBot);
            }
            else
            {
                await _commands[command](update.Message, userBot);
            }
        }
    }

    public async Task HandleStartCommand(Message message, UserBot user)
    {

    }

    public async Task HandleAddMixCommand(Message message, UserBot user)
    {

    }

    public async Task HandleSearchCommand(Message message, UserBot user)
    {

    }

    public async Task HandleTopMixesCommand(Message message, UserBot user)
    {

    }

    public async Task HandleProfileCommand(Message message, UserBot user)
    {
        var profileText = $"""
                           📊 <b>Профиль пользователя</b>

                           🔖 Username: {user.Username}
                           🆔 Telegram ID: {user.TelegramId}
                           📅 Дата регистрации: {user.RegistrationDate:dd.MM.yyyy}
                           ⭐ Роль: {user.Role}

                           📈 Статистика:
                           • Создано миксов: {user.CreatedMixes.Count}
                           • В избранном: {user.FavoritesMix.Count}
                           • Оставлено оценок: {user.Ratings.Count}
                           """;

        await _botClient.SendMessage(
            chatId: message.Chat.Id,
            text: profileText,
            parseMode: ParseMode.Html,
            replyMarkup: TelegramKeyboards.GetProfileKeyboard());
    }

    public async Task HandleUnknoweCommand(Message message, UserBot user)
    {

    }

    public async Task HandleMyMixesCommand(Message message, UserBot user)
    {
        var mixes = await _userService.GetUserFavoritesAsync(user.TelegramId);

        if (!mixes.Any())
        {
            await _botClient.SendMessage(chatId: message.Chat.Id,
                text: "У вас пока нет миксов. Создать новый микс командой ",
                replyMarkup: TelegramKeyboards.GetMainKeyboard());
            return;
        }

        var respons = "<b> ваши миксы:<b>\n\n";
        foreach (var mix in mixes.Take(10))
        {
            respons += $"<b>{mix.Name}<b>\n";
            respons += $"{mix.Desctiption}";
            respons += $"рейтинг {mix.AcerageRating}";
            respons += $"{mix.CreatedAt:dd.MM.yyyy}\n";
            respons += $"-----------------------------\n";
        }

        await _botClient.SendMessage(chatId: message.Chat.Id,
            text: respons,
            parseMode: ParseMode.Html);
    }

    public async Task HandleFavoritesCommand(Message message, UserBot user)
    {
        var favorites = await _userService.GetUserFavoritesAsync(user.TelegramId);
        if (!favorites.Any())
        {
            await _botClient.SendMessage(chatId: message.Chat.Id,
                text: "У вас нет избранных миксов",
                replyMarkup: TelegramKeyboards.GetMainKeyboard());
            return;
        }
        
        var respons = "<b>ваши Миксы:</b>\n\n";
        foreach (var favorite in favorites)
        {
            respons += $"<b>{favorite.Name}<b>\n";
            respons += $"{favorite.Desctiption}";
            respons += $"рейтинг {favorite.AcerageRating}";
            respons += $"{favorite.CreatedAt:dd.MM.yyyy}\n";
            respons += $"-----------------------------\n";
        }
    }
}