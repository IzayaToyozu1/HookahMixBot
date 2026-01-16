namespace HookahMixBot.Core.Entities;

public class UserFavorite
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int MixId { get; set; }
    public Mix Mix { get; set; }
    public DateTime AddedAt { get; set; }
}