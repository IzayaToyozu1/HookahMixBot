using Telegram.Bot.Types.ReplyMarkups;

namespace HookMixBot.Telegram.Keyboards;

public static class TelegramKeyboards
{
    public static ReplyKeyboardMarkup GetMainKeyboard()
    {
        return new ReplyKeyboardMarkup(new[]
        {
            new[]
            {
                new KeyboardButton("Мои миксы"),
                new KeyboardButton("Новый микс")
            },
            new []
            {
              new KeyboardButton("Избранное"),
              new KeyboardButton("Поиск"),
            },
            new []
            {
                new KeyboardButton("Топ миксов"),
                new KeyboardButton("Профиль")
            }
        })
        {
            ResizeKeyboard = true,
        };
    }

    public static InlineKeyboardMarkup GetMixActionsKeyboard(int mixId)
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Добавить в избранное", $"fav_{mixId}"),
                InlineKeyboardButton.WithCallbackData("Оценить", $"rate_{mixId}"),
            },
            new[]
            {
              InlineKeyboardButton.WithCallbackData("Редактировать", $"edit_{mixId}"),
              InlineKeyboardButton.WithCallbackData("Удалить", $"delete_{mixId}"), 
            },
        });
    }

    public static InlineKeyboardMarkup GetProfileKeyboard()
    {
        return new InlineKeyboardMarkup(new[]
        {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Настройки", "settings"), 
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Статистика", "stats"),
                InlineKeyboardButton.WithCallbackData("Экспорт", "export"), 
            }
        });
    }
}