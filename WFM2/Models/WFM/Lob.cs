using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WFM2.Models.WFM
{
    public partial class Lob
    {
        public Lob()
        {
            EmpGrpLob = new HashSet<EmpGrpLob>();
            ForGrpLob = new HashSet<ForGrpLob>();
            StfGrpLob = new HashSet<StfGrpLob>();
            Split = new HashSet<Split>();
        }

        public int Id { get; set; }
        public int? DeptId { get; set; }
        [Display(Name = "Lob")]
        public string Lob1 { get; set; }
        [Display(Name = "FTE Definition")]
        public int? FteDefinition { get; set; }

        public virtual ICollection<EmpGrpLob> EmpGrpLob { get; set; }
        public virtual ICollection<ForGrpLob> ForGrpLob { get; set; }
        public virtual ICollection<StfGrpLob> StfGrpLob { get; set; }
        public virtual ICollection<Split> Split { get; set; }
        public virtual Dept Dept { get; set; }
    }
}
