using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Entities
{
    public class Skill : EntityBase
    {
        public string Name { get; set; }
        public int Percentage { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } //ManyToOne

        //public SkillType SkillType { get; set; } //ManyToOne
    }
}
