using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class AClaim
    {
        public AClaim()
        {
            ARoleClaim = new HashSet<ARoleClaim>();
            AUserClaim = new HashSet<AUserClaim>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public byte ClaimType { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ARoleClaim> ARoleClaim { get; set; }
        public virtual ICollection<AUserClaim> AUserClaim { get; set; }
    }
}
