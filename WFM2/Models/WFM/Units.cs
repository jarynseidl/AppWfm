using System;
using System.Collections.Generic;

namespace WFM2.Models.WFM
{
    public partial class Units
    {
        public long Id { get; set; }
        public int? ProdId { get; set; }
        public int? YearNum { get; set; }
        public byte? MonthNum { get; set; }
        public int? UnitCount { get; set; }
        public int? Activations { get; set; }
        public int? Deactivations { get; set; }

        public virtual Product Prod { get; set; }
    }
}
