using Microsoft.EntityFrameworkCore;
using Task_Manager_API_Backend.Models.Entity;

namespace Task_Manager_API_Backend.Data;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    
}