using HookahMixBot.Core.Entities;

namespace HookahMixBot.Core.Interfaces;

public interface IMixRepository: IRepository<Mix>
{
    Task<IEnumerable<Mix>> GetByTobaccoBrandAsync(string brand);
    Task<IEnumerable<Mix>> SearchAsync(string query);
    Task<IEnumerable<Mix>> GetTopRatedAsync(int count);
}