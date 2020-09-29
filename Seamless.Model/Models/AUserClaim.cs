using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class AUserClaim
    {
        public int UserId { get; set; }
        public byte ClaimId { get; set; }
        public string ClaimValue { get; set; }

        public virtual AClaim Claim { get; set; }
        public virtual AUser User { get; set; }
    }
}
