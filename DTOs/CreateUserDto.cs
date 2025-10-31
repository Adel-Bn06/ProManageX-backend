

namespace SmartTasks.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required,EmailAddress] // ce champs est obligatoire et il faut une adresse email valide
        public string Email { get; set; } = string.Empty;
        [Required,MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
