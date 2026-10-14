

using domain.src.church;

public class ChurchMembership
{
    public string UserId { get; set; } = string.Empty;

    public Guid ChurchId { get; set; }

    public Church Church { get; set; } = null!;

    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
}