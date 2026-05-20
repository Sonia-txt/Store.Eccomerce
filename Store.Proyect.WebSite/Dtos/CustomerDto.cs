using System.ComponentModel.DataAnnotations;

namespace Store.Proyect.WebSite.Dtos;

public class CustomerDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress(ErrorMessage = "Formato de correo inválido")]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string Phone { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
}