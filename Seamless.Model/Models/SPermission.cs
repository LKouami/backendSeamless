using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class SPermission
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int Level { get; set; }
        public byte Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
