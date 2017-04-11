using System;
using System.Collections.Generic;

namespace WFM2.Models.WFM
{
    public partial class EmpGrp
    {
        public EmpGrp()
        {
            EmpGrpLob = new HashSet<EmpGrpLob>();
        }

        public decimal EmpGrpNodeSk { get; set; }
        public decimal? EmpGrpClassSk { get; set; }
        public string Code { get; set; }

        public virtual ICollection<EmpGrpLob> EmpGrpLob { get; set; }
    }
}
