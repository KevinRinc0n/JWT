using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class AddRoleDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string UserPassword { get; set; }
    [Required]
    public string Rol { get; set; }
}
