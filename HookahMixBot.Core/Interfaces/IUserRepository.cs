using HookahMixBot.Core.Entities;

namespace HookahMixBot.Core.Interfaces;

public interface IUserRepository: IRepository<UserBot>
{
    Task<UserBot> GetByTelegramIdAsync(long telegramId);
    Task<UserBot> GetByIdAsync(long userId);
    Task<IEnumerable<UserBot>> SearchAsync(string query);
    Task UpdateLastActivityAsync(long userId);
}