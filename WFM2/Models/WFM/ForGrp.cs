using System;
using System.Collections.Generic;

namespace WFM2.Models.WFM
{
    public partial class ForGrp
    {
        public ForGrp()
        {
            ForGrpLob = new HashSet<ForGrpLob>();
            IdpFgDet = new HashSet<IdpFgDet>();
        }

        public decimal ForGrpSk { get; set; }
        public string Code { get; set; }
        public decimal? TimeZoneSk { get; set; }

        public virtual ICollection<ForGrpLob> ForGrpLob { get; set; }
        public virtual ICollection<IdpFgDet> IdpFgDet { get; set; }
    }
}
