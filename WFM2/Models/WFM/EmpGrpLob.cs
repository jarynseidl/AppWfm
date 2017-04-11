using System;
using System.Collections.Generic;

namespace WFM2.Models.WFM
{
    public partial class EmpGrpLob
    {
        public int Id { get; set; }
        public decimal EmpGrpNodeSk { get; set; }
        public int? LobId { get; set; }
        public int? VendorId { get; set; }
        public int? SiteId { get; set; }

        public virtual EmpGrp EmpGrpNodeSkNavigation { get; set; }
        public virtual Lob Lob { get; set; }
        public virtual Site Site { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
