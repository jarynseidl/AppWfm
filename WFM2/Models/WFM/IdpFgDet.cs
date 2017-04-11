using System;
using System.Collections.Generic;

namespace WFM2.Models.WFM
{
    public partial class IdpFgDet
    {
        public long Id { get; set; }
        public decimal? IdpSk { get; set; }
        public decimal? ForGrpSk { get; set; }
        public string Element { get; set; }
        public DateTime? Period { get; set; }
        public decimal? Value { get; set; }

        public virtual ForGrp ForGrpSkNavigation { get; set; }
    }
}
