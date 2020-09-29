using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class ARoleClaim
    {
        public byte RoleId { get; set; }
        public byte ClaimId { get; set; }
        public string ClaimValue { get; set; }

        public virtual AClaim Claim { get; set; }
        public virtual ARole Role { get; set; }
    }
}
