namespace HookahMixBot.Core.Entities;

public class Mix
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Desctiption { get; set; }
    public List<Tobacco> Tobaccos { get; set; }
    public double BowPercentage { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Rating { get; set; }
    public List<string> Tags {get; set;}
}