namespace MvcAuth.Models;

public class Team
{
    public int TeamID { get; set; }
    public string TeamName { get; set; }

    // Navigation property for the users in the team
    public ICollection<UserTeam>? UserTeams { get; set; }
    
    // Navigation property for tasks associated with the team
    public ICollection<Assignment>? Assignment { get; set; }
    
}