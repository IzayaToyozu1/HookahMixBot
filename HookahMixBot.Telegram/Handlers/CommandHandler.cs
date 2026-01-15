using HookahMixBot.Application.Commands;
using Telegram.Bot.Types;

namespace HookahMixBot.Telegram.Handlers;

public class CommandHandler : ITelegramUpdateHandler
{
    private readonly Dictionary<string, Func<Message, Task>> _commands;
    private readonly AddMixCommandHandler _addMixHandler;

    public CommandHandler(AddMixCommandHandler addMixHandler)
    {
        _addMixHandler = addMixHandler;

        _commands = new Dictionary<string, Func<Message, Task>>
        {
            { "/start", HandleStartCommand },
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

    public async Task HandleStartCommand(Message message)
    {
        
    }

    public async Task HandleAddMixCommand(Message message)
    {
        
    }

    public async Task HandleSearchCommand(Message message)
    {
        
    }

    public async Task HandleTopMixesCommand(Message message)
    {
        
    }
}