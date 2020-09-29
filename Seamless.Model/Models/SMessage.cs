using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class SMessage
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long TicketId { get; set; }
        public string Text { get; set; }
        public byte Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
