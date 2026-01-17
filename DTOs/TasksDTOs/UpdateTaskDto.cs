using System.ComponentModel.DataAnnotations;

namespace Task_Manager_API_Backend.DTOs;

public class UpdateTaskDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public bool IsCompleted { get; set; }
}