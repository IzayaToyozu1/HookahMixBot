using HookahMixBot.Core.Entities;
using HookahMixBot.Core.Interfaces;

namespace HookahMixBot.Application.Service;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMixRepository _mixRepository;

    public UserService(IUserRepository userRepository, IMixRepository mixRepository)
    {
        _userRepository = userRepository;
        _mixRepository = mixRepository;
    }
    
    public async Task<UserBot> GetOrCreateUserAsync(long telegramId, string? name)
    {
        var user = await _userRepository.GetByTelegramIdAsync(telegramId);
        
        if(user == null)
        {
            user = new UserBot()
            {
                TelegramId = telegramId,
                Username = name,
                RegistrationDate = DateTime.UtcNow,
                LastActivity = DateTime.UtcNow,
            };
            await _userRepository.AddAsync(user);
        }
        else
        {
            user.Username = name;
            user.LastActivity = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);
        }
        
        return user;
    }

    public async Task<UserBot> GetUserAsync(long telegramId)
    {
        return await _userRepository.GetByTelegramIdAsync(telegramId);
    }

    public async Task UpdateUserFrofileAsync(long telegramId, UserProfileDto profile)
    {

    }

    public async Task<IEnumerable<Mix>> GetUserFavoritesAsync(long telegramId)
    {
        var user = await GetUserAsync(telegramId);
        if (user == null) 
            return Enumerable.Empty<Mix>();
        return await _mixRepository.GetByUserAsync(user.Id);
    }

    public Task AddToFavoritesAsync(long telegramId, long mixId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveFromFavoritesAsync(long telegramId, long mixId)
    {
        throw new NotImplementedException();
    }
}