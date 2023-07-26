﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.DTOs
{
    internal class ExperienceDTO
    {
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Description { get; set; }
        public int PersonID { get; set; }

        //public int ExperienceTypeID { get; set; }
    }
}
