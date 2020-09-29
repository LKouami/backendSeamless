﻿using System;
using System.Collections.Generic;

namespace Seamless.Model.Models
{
    public partial class SAppParameter
    {
        public int Id { get; set; }
        public string ParameterName { get; set; }
        public string Section { get; set; }
        public string Value { get; set; }
        public string DefaultValue { get; set; }
        public string TypeParameter { get; set; }
        public string ValuesList { get; set; }
        public byte Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
