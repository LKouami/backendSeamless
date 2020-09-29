using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class SActivityLog
    {
        public long Id { get; set; }
        public string Action { get; set; }
        public string Libelle { get; set; }
        public long UserId { get; set; }
        public byte Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
