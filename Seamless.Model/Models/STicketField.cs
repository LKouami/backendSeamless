using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class STicketField
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int Order { get; set; }
        public int IsRequired { get; set; }
        public string ChoiceList { get; set; }
        public byte Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
