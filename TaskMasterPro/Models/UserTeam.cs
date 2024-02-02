namespace MvcAuth.Models;

public class UserTeam
{
    public string UserId { get; set; }
    public AdvanceUser User { get; set; }

    public int TeamId { get; set; }
    public Team Team { get; set; }

    public bool IsMenager { get; set; }
}