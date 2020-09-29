using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class AUserRole
    {
        public int UserId { get; set; }
        public byte RoleId { get; set; }

        public virtual ARole Role { get; set; }
        public virtual AUser User { get; set; }
    }
}
