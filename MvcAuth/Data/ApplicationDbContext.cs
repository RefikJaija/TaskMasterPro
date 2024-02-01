using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcAuth.Models;

namespace MvcAuth.Data;

public class ApplicationDbContext : IdentityDbContext<AdvanceUser>
{
    //Tables we want to create
    public virtual DbSet<Assignment> Assignment { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<AdvanceUser> Users { get; set; }
    public virtual DbSet<UserTeam> UserTeams { get; set; }
    
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    //Build the relationships between the tables
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //We are inheriting from the base class and we are passing the parameters to the base class constructor
        base.OnModelCreating(modelBuilder);

        // Define many-to-many relationship between User and Team entities
        modelBuilder.Entity<UserTeam>()
            .HasKey(ut => new { ut.UserId, ut.TeamId });

        modelBuilder.Entity<UserTeam>()
            .HasOne(ut => ut.User)
            .WithMany(u => u.UserTeams)
            .HasForeignKey(ut => ut.UserId);

        modelBuilder.Entity<UserTeam>()
            .HasOne(ut => ut.Team)
            .WithMany(t => t.UserTeams)
            .HasForeignKey(ut => ut.TeamId);
        

        // Add primary key for the Tasks entity
        modelBuilder.Entity<Assignment>()
            .HasKey(t => t.AssignmentID);

        // Your existing configuration for Task and User relationships remains unchanged
        modelBuilder.Entity<Assignment>()
            .HasOne(t => t.User)
            .WithMany(u => u.Assignment)
            .HasForeignKey(t => t.UserID);
        
        // Define the one-to-many relationship between Assignment and Team entities
        modelBuilder.Entity<Assignment>()
            .HasOne(a => a.Team)
            .WithMany(t => t.Assignment)
            .HasForeignKey(a => a.TeamId);
    }
}