namespace HookahMixBot.Core.Entities;

public class Tobacco
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Flavor { get; set; }
    public TobaccoStrength Strength { get; set; }
}