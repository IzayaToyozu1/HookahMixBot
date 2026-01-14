using HookahMixBot.Core.Entities;

namespace HookahMixBot.Application.Commands;

public class AddMixCommand
{
    public string Name { get; set; }
    public string Desctription { get; set; }
    public List<Tobacco> Tobaccos { get; set; }
    public string CreateBy { get; set; }
}