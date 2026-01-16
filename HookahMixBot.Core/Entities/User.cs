namespace HookahMixBot.Core.Entities;

public class User
{
    public int Id { get; set; }
    public long TelegramId { get; set; }
    public string Username { get; set; }
    public DateTime RegistrationDate { get; set; } //first login to the bot
    public DateTime LastActivity { get; set; }
    public UserRole Role { get; set; }
}