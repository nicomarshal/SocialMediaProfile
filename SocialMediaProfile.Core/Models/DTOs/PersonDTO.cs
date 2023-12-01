using System.ComponentModel.DataAnnotations;

namespace SocialMediaProfile.Core.Models.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string ProfileImg { get; set; } = "";

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "El campo Profesión es obligatorio.")]
        public string Profession { get; set; }

        public string AboutMe { get; set; }
        public int UserId { get; set; }
    }
}
