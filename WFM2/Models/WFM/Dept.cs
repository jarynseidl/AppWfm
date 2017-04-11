using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WFM2.Models.WFM
{
    public partial class Dept
    {
        public Dept()
        {
            Lob = new HashSet<Lob>();
        }

        public int Id { get; set; }
        [Display(Name = "Dept")]
        public string Name { get; set; }
        public string Abbrev { get; set; }

        public virtual ICollection<Lob> Lob { get; set; }
    }
}
