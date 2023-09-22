﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.DataAccess.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Person Person { get; set; } //OneToOne

        public int RoleId { get; set; }
        public Role Role { get; set; } //ManyToOne      
    }
}