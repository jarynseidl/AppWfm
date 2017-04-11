using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WFM2.Models.WFM
{
    public partial class Site
    {
        public Site()
        {
            EmpGrpLob = new HashSet<EmpGrpLob>();
            ForGrpLob = new HashSet<ForGrpLob>();
            StfGrpLob = new HashSet<StfGrpLob>();
        }

        public int Id { get; set; }
        [Display(Name = "Site")]
        public string Site1 { get; set; }
        public int? VendorId { get; set; }
        public string Location { get; set; }

        public virtual ICollection<EmpGrpLob> EmpGrpLob { get; set; }
        public virtual ICollection<ForGrpLob> ForGrpLob { get; set; }
        public virtual ICollection<StfGrpLob> StfGrpLob { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
