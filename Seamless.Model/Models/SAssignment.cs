using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class SAssignment
    {
        public long Id { get; set; }
        public long TicketId { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string ClosedUserId { get; set; }
        public int? CloseReasonId { get; set; }
        public long? AssigneeId { get; set; }
        public long? AssignerId { get; set; }
        public byte Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
