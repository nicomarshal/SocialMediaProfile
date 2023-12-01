using System.ComponentModel.DataAnnotations;

namespace SocialMediaProfile.Core.Models.DTOs
{
    public class EducationDTO
    {
        public int Id { get; set; }
        public string Logo { get; set; } = "";

        [Required(ErrorMessage = "El campo Institución es obligatorio.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "El campo Carrera es obligatorio.")]
        public string Career { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Inicio es obligatorio.")]
        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        //public int EducationTypeId { get; set; }
    }
}
