using System;
using System.Collections.Generic;

namespace WFM2.Models.WFM
{
    public partial class IdpDet
    {
        public decimal IdpSk { get; set; }
        public decimal StfGrpSk { get; set; }
        public string Element { get; set; }
        public DateTime Period { get; set; }
        public decimal? Value { get; set; }
    }
}
