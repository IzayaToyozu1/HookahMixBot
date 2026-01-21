using HookahMixBot.Core.Entities;
using HookahMixBot.Core.Interfaces;

namespace HookahMixBot.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<UserBot> _users = new List<UserBot>();
    private int _nextId = 1;
    
    public Task<UserBot> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserBot>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(UserBot entity)
    {
        entity.Id = _nextId++;
        entity.RegistrationDate = DateTime.UtcNow;
        entity.LastActivity = DateTime.UtcNow;
        _users.Add(entity);
        await Task.CompletedTask;
    }

    public Task UpdateAsync(UserBot entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserBot> GetByTelegramIdAsync(long telegramId)
    {
        return await Task.FromResult(_users.FirstOrDefault(u => u.TelegramId == telegramId));
    }

    public Task<UserBot> GetByIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserBot>> SearchAsync(string query)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateLastActivityAsync(long userId)
    {
        var user = await GetByIdAsync(userId);
        if (user != null)
        {
            user.LastActivity = DateTime.UtcNow;
            await UpdateAsync(user);
        }
    }
}

