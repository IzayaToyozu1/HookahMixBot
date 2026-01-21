using HookahMixBot.Core.Entities;

namespace HookahMixBot.Application.Service;

public interface IUserService
{
    Task<UserBot> GetOrCreateUserAsync(long telegramId, string? name);
    Task<UserBot> GetUserAsync(long telegramId);
    Task UpdateUserFrofileAsync(long telegramId, UserProfileDto profile);
    Task<IEnumerable<Mix>> GetUserFavoritesAsync(long telegramId);
    Task AddToFavoritesAsync(long telegramId, long mixId);
    Task RemoveFromFavoritesAsync(long telegramId, long mixId);
}