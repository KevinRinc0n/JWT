using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class RegisterDto
{
    [Required]
    public string UserEmail { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string UserPassword { get; set; }
}
