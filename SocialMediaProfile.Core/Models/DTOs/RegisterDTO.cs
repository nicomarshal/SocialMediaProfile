using System.ComponentModel.DataAnnotations;

namespace SocialMediaProfile.Core.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo Correo electrònico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Alias es obligatorio.")]
        public string Alias { get; set; }
        public int RoleId { get; set; }
    }
}
