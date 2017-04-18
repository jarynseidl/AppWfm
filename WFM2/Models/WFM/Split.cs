using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WFM2.Models.WFM
{
    public partial class Split
    {
        public int SplitId { get; set; }
        public int? VendorId { get; set; }
        public short Acd { get; set; }
        [Display(Name = "Split")]
        public short Split1 { get; set; }
        public int? LobId { get; set; }
        public bool CTF { get; set; }

        public virtual Lob Lob { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
