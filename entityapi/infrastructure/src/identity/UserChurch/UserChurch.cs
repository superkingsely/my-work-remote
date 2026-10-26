

public class UserChurch
{
    public Guid Id { get; set; }

    // Foreign key to ASP.NET Identity User
    public string UserId { get; set; } = string.Empty;

    public User User { get; set; } = null!;

    // Foreign key to Church
    public Guid ChurchId { get; set; }

    public Church Church { get; set; } = null!;
}