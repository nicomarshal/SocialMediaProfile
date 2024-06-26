﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Entities
{
    public class Role : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<User> Users { get; set; } //OneToMany
    }
}
