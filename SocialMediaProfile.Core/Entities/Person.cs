using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Entities
{
    public class Person : EntityBase
    {
        public string ProfileImg { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Profession { get; set; }
        public string AboutMe { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } //OneToOne


        public List<Experience> Experiencies { get; set; } //OneToMany
        public List<Education> Educations { get; set; } //OneToMany
        public List<Skill> Skills { get; set; } //OneToMany
        public List<Project> Projects { get; set; } //OneToMany
    }
}
