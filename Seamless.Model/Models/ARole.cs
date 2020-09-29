using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class ARole
    {
        public ARole()
        {
            ARoleClaim = new HashSet<ARoleClaim>();
            AUserRole = new HashSet<AUserRole>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ARoleClaim> ARoleClaim { get; set; }
        public virtual ICollection<AUserRole> AUserRole { get; set; }
    }
}
