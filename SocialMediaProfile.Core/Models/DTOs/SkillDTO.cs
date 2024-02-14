using System.ComponentModel.DataAnnotations;

namespace SocialMediaProfile.Core.Models.DTOs
{
    public class SkillDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Skill es obligatorio.")]
        public string Name { get; set; }

        public int Percentage { get; set; } = 0;
        public int UserId { get; set; }

        //public int SkillTypeID { get; set; }
    }
}
