using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class STicket
    {
        public long Id { get; set; }
        public int CategoryId { get; set; }
        public int ParentId { get; set; }
        public long UserId { get; set; }
        public int PriorityId { get; set; }
        public string Object { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public int State { get; set; }
        public byte Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
