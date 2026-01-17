using System.ComponentModel.DataAnnotations;

namespace Task_Manager_API_Backend.Models.Entity;

public class User
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string? Email { get; set; }
    
    [Required]
    public string PasswordHash { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}