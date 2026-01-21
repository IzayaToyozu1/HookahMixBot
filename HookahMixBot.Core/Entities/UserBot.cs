namespace HookahMixBot.Core.Entities;

public class UserBot
{
    public int Id { get; set; }
    public long TelegramId { get; set; }
    public string Username { get; set; }
    public DateTime RegistrationDate { get; set; } //first login to the bot
    public DateTime LastActivity { get; set; }
    public UserRole Role { get; set; }
    
    public ICollection<Mix> CreatedMixes { get; set; } = new List<Mix>();
    public ICollection<UserFavorite> FavoritesMix { get; set; } = new List<UserFavorite>();
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}