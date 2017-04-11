using System;
using System.Collections.Generic;

namespace WFM2.Models.WFM
{
    public partial class StfGrpLob
    {
        public int Id { get; set; }
        public decimal StfGrpSk { get; set; }
        public int? LobId { get; set; }
        public int? VendorId { get; set; }
        public int? SiteId { get; set; }

        public virtual Site Site { get; set; }
        public virtual Lob Lob { get; set; }
        public virtual StfGrp StfGrpSkNavigation { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
