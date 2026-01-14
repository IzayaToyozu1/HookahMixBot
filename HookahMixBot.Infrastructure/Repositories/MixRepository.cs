using HookahMixBot.Core.Entities;
using HookahMixBot.Core.Interfaces;

namespace HookahMixBot.Infrastructure.Repositories;

public class MixRepository : IMixRepository
{
    private readonly List<Mix> _mixes = new();
    private int _nextId = 1;
    
    public Task<Mix> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Mix>> GetAllAsync()
    {
        return await Task.FromResult(_mixes.AsReadOnly());
    }

    public async Task AddAsync(Mix entity)
    {
        entity.Id = _nextId++;
        entity.CreatedAt = DateTime.UtcNow;
        _mixes.Add(entity);
        await Task.CompletedTask;
    }

    public Task UpdateAsync(Mix entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Mix>> GetByTobaccoBrandAsync(string brand)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Mix>> SearchAsync(string query)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Mix>> GetTopRatedAsync(int count)
    {
        throw new NotImplementedException();
    }
}