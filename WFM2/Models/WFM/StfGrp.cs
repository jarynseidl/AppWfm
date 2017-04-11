using System;
using System.Collections.Generic;

namespace WFM2.Models.WFM
{
    public partial class StfGrp
    {
        public StfGrp()
        {
            StfGrpLob = new HashSet<StfGrpLob>();
        }

        public decimal StfGrpSk { get; set; }
        public decimal? EmpGrpNodeSk { get; set; }
        public string Code { get; set; }
        public decimal? TimeZoneSk { get; set; }

        public virtual ICollection<StfGrpLob> StfGrpLob { get; set; }
    }
}
