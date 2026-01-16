namespace HookahMixBot.Core.Entities;

public class Mix
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Desctiption { get; set; }
    public List<Tobacco> Tobaccos { get; set; }
    public double BowPercentage { get; set; }
    
    public int CreateByUserUd { get; set; }
    public User CreateBy { get; set; }

    public DateTime CreatedAt { get; set; }
    public bool IsPublic { get; set; }
    public List<string> Tags { get; set; }

    public double AcerageRating => Ratings?.Any() == true ? Ratings.Average(r => r.Value) : 0;
    
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}