using HookahMixBot.Application.Commands;
using HookahMixBot.Application.Service;
using HookahMixBot.Core.Entities;
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
            { "/prifile", HandleProfileCommand},
            { "/addmix", HandleAddMixCommand },
            { "/search", HandleSearchCommand },
            { "/top", HandleTopMixesCommand },
        };
    }
    
    public async Task HandleUpdateAsync(Update update)
    {
        if (update.Message?.Text != null)
        {
            var command = update.Message.Text.Split(' ')[0].ToLower();

            if (_commands.ContainsKey(command))
            {
                await _commands[command](update.Message);
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

                            🔖 Username: @{{user.Username}}
                            🆔 Telegram ID: {{user.TelegramId}}
                            📅 Дата регистрации: {{user.RegistrationDate:dd.MM.yyyy}}
                            ⭐ Роль: {{user.Role}}
                            
                            📈 Статистика:
                            • Создано миксов: {user.CreatedMixes.Count}
                            • В избранном: {user.FavoritesMix.Count}
                            • Оставлено оценок: {user.Ratings.Count}
                            """;

        await _botClient.SendMessage(
            chatId: message.Chat.Id,
            text: profileText,
            parseMode: ParseMode.Html,
            replyMarkup: GetProfileKeyboard());
    }
}