using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "El campo de email es obligatorio.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Debes indicar un email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo de contraseña es obligatorio.")]
        public string Password { get; set; }
    }
}
