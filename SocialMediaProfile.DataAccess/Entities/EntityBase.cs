using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.DataAccess.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
