﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Models.DTOs
{
    public class SkillDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Percentage { get; set; }
        public int UserId { get; set; }

        //public int SkillTypeID { get; set; }
    }
}
