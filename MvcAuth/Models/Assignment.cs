using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MvcAuth.Models;

public class Assignment 
{
    [Key]
    public int AssignmentID { get; set; }
    
    
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; }
    public string? UserID { get; set; }
    // Navigation property for the user the task is assigned to
    public AdvanceUser? User { get; set; }
    public int? TeamId { get; set; }
    // Navigation property for the team the task is assigned to
    public Team? Team { get; set; }
    
    
    
}