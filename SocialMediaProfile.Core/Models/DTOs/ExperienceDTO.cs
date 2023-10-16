using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Models.DTOs
{
    public class ExperienceDTO
    {
        public string Logo { get; set; }

        [Required(ErrorMessage = "El campo Empresa es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Puesto es obligatorio.")]
        public string Job { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Inicio es obligatorio.")]      
        public DateTime StartDate { get; set; } 

        public DateTime FinishDate { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        //public int ExperienceTypeID { get; set; }
    }
}
