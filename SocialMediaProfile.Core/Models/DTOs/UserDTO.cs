﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Models.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        //public int RoleId { get; set; }
    }
}