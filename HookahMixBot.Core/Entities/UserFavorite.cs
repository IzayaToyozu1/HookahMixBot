namespace HookahMixBot.Core.Entities;

public class UserFavorite
{
    public int UserId { get; set; }
    public UserBot UserBot { get; set; }
    public int MixId { get; set; }
    public Mix Mix { get; set; }
    public DateTime AddedAt { get; set; }
}