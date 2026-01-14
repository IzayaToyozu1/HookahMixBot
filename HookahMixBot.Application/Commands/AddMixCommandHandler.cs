using HookahMixBot.Core.Interfaces;
using HookahMixBot.Core.Entities;

namespace HookahMixBot.Application.Commands;

public class AddMixCommandHandler
{
    private readonly IMixRepository _mixRepository;

    public AddMixCommandHandler(IMixRepository mixRepository)
    {
        _mixRepository = mixRepository;
    }

    public async Task<Mix> Handle(AddMixCommand command)
    {
        var mix = new Mix()
        {
            Name = command.Name,
            Desctiption = command.Desctription,
            CreatedBy = command.CreateBy,
            Tobaccos = command.Tobaccos.Select(t => new Tobacco
            {
                Brand = t.Brand,
                Flavor = t.Flavor,
                Strength = t.Strength
            }).ToList()
        };
        
        await _mixRepository.AddAsync(mix);
        return mix;
    }
}