﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.DTOs
{
    public class PersonDTO
    {
        public string ProfileImg { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Profession { get; set; }
        public string AboutMe { get; set; }
        public int UserID { get; set; }
    }
}
