using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Entities
{
    public class Project : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Images { get; set; }
        public string URL { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; } //ManyToOne
    }
}
