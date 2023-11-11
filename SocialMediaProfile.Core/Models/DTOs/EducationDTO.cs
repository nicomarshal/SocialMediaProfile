using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Models.DTOs
{
    public class EducationDTO
    {
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Career { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int UserId { get; set; }

        //public int EducationTypeId { get; set; }
    }
}
