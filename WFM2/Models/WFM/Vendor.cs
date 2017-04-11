using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WFM2.Models.WFM
{
    public partial class Vendor
    {
        public Vendor()
        {
            EmpGrpLob = new HashSet<EmpGrpLob>();
            ForGrpLob = new HashSet<ForGrpLob>();
            HSplit = new HashSet<HSplit>();
            Site = new HashSet<Site>();
            StfGrpLob = new HashSet<StfGrpLob>();
            Split = new HashSet<Split>();
        }

        public int Id { get; set; }
        [Display(Name = "Vendor")]
        public string Vendor1 { get; set; }
        public string Abbrev { get; set; }

        public virtual ICollection<EmpGrpLob> EmpGrpLob { get; set; }
        public virtual ICollection<ForGrpLob> ForGrpLob { get; set; }
        public virtual ICollection<HSplit> HSplit { get; set; }
        public virtual ICollection<Site> Site { get; set; }
        public virtual ICollection<StfGrpLob> StfGrpLob { get; set; }
        public virtual ICollection<Split> Split { get; set; }
    }
}
