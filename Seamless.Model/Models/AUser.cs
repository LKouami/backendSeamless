using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class AUser
    {
        public AUser()
        {
            AUserClaim = new HashSet<AUserClaim>();
            AUserRole = new HashSet<AUserRole>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public byte Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<AUserClaim> AUserClaim { get; set; }
        public virtual ICollection<AUserRole> AUserRole { get; set; }
    }
}
