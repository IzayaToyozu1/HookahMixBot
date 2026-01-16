using HookahMixBot.Core.Entities;

namespace HookahMixBot.Core.Interfaces;

public interface IUserService
{
    Task<User> GetByTelegramIdAsync(long telegramId);
    Task<IEnumerable<User>> SearchAsync(string query);
    Task UpdateLastActivityAsync(int userId);
}