using System.ComponentModel.DataAnnotations;

namespace SocialMediaProfile.Core.Models.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Inicio es obligatorio.")]
        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public string URL { get; set; }
        public int UserId { get; set; }
    }
}
