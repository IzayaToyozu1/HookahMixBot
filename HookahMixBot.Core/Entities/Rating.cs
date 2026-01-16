namespace HookahMixBot.Core.Entities;

public class Rating
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int MixId { get; set; }
    public Mix Mix { get; set; }
    
    public int Value { get; set; }
    public DateTime RatedAt { get; set; }
    public string Comment { get; set; }
}