namespace MvcAuth.Models;

public class AssignmentViewModel
{
    public Assignment Assignment { get; set; }
    public List<Team>? Teams { get; set; }

    // SelectedTeamId property to bind the selected team ID from the dropdown list
    public int? SelectedTeamId { get; set; }
}