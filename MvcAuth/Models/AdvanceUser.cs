using Microsoft.AspNetCore.Identity;

namespace MvcAuth.Models;

public class AdvanceUser : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string MobileNumber { get; set; }
    
    // Navigation property for the tasks assigned to the user
    public ICollection<Assignment>? Assignment { get; set; }

    // Navigation property for the teams the user belongs to
    public ICollection<UserTeam>? UserTeams { get; set; }
    
    
}
