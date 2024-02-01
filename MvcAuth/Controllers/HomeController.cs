using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcAuth.Data;
using MvcAuth.Models;

namespace MvcAuth.Controllers;



[Authorize]
public class HomeController : Controller
{
    private bool AssignmentExists(int id)
    {
        return _context.Assignment.Any(e => e.AssignmentID == id);
    }

    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;

    }

 public async Task<IActionResult> Index()
    {
       
        // Get the ID of the logged-in user
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        // Query assignments associated with the logged-in user
        var userAssignments = await _context.Assignment
            .Where(a => a.UserID == userId)
            .ToListAsync();

        // Group assignments by status
        var groupedAssignments = userAssignments.GroupBy(a => a.Status)
            .ToDictionary(g => g.Key, g => g.ToList());

        return View(groupedAssignments);
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var userTeams = await _context.UserTeams
            .Where(ut => ut.UserId == userId)
            .Select(ut => ut.Team)
            .ToListAsync();

        var viewModel = new AssignmentViewModel
        {
            Teams = userTeams ?? new List<Team>(), // Handle null case by providing an empty list
            Assignment = new Assignment()
        };

        return View(viewModel);
    }
    

    [HttpPost]
    public async Task<IActionResult> Create(AssignmentViewModel viewModel)
    {
        
        viewModel.Assignment.TeamId = viewModel.SelectedTeamId;
        // Get the ID of the logged-in user
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        viewModel.Assignment.UserID = userId;
        
        // Retrieve all users belonging to the selected team
        var teamUsers = await _context.UserTeams
            .Where(ut => ut.TeamId == viewModel.SelectedTeamId)
            .Select(ut => ut.UserId)
            .ToListAsync();

        
            try
            {
                await _context.Assignment.AddAsync(viewModel.Assignment);
                // Create an assignment for each user in the team
                foreach (var teamUserId in teamUsers)
                {
                    var assignment = new Assignment
                    {
                        Name = viewModel.Assignment.Name,
                        Description = viewModel.Assignment.Description,
                        DueDate = viewModel.Assignment.DueDate,
                        Priority = viewModel.Assignment.Priority,
                        Status = viewModel.Assignment.Status,
                        UserID = teamUserId, // Assign the user ID from the team
                        TeamId = viewModel.SelectedTeamId
                    };
            
                    await _context.Assignment.AddAsync(assignment);
                }
                //SaveChanges to Database
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, $"Somthing Went Wrong{e.Message}");
            }
            
        return View(viewModel);
    }

    // HTTPGet action to display the delete confirmation view
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var assignment = await _context.Assignment.FindAsync(id);
        if (assignment == null)
        {
            return NotFound(); // Return a 404 Not Found error if the assignment with the given ID doesn't exist
        }
        return View(assignment);
    }

// HTTPPost action to handle the delete request
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment == null)
            {
                return NotFound(); // Return a 404 Not Found error if the assignment with the given ID doesn't exist
            }

            _context.Assignment.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, $"Something went wrong: {e.Message}");
            return View();
        }
    }
   

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}