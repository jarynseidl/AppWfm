using System;
using System.Collections.Generic;

namespace WFM2.Models.WFM
{
    public partial class HSplit
    {
        public DateTime RowDate { get; set; }
        public TimeSpan Interval { get; set; }
        public int VendorId { get; set; }
        public short Acd { get; set; }
        public short Split { get; set; }
        public int? IAvailtime { get; set; }
        public int? IRingtime { get; set; }
        public int? Ringtime { get; set; }
        public short? Ringcalls { get; set; }
        public int? IAcdtime { get; set; }
        public int? Acdtime { get; set; }
        public short? Acdcalls { get; set; }
        public int? IAcwtime { get; set; }
        public int? Acwtime { get; set; }
        public int? IAcwouttime { get; set; }
        public int? Acwouttime { get; set; }
        public short? Acwoutcalls { get; set; }
        public int? IAcwintime { get; set; }
        public int? Acwintime { get; set; }
        public short? Acwincalls { get; set; }
        public int? IAuxtime { get; set; }
        public int? IAuxouttime { get; set; }
        public int? Auxouttime { get; set; }
        public short? Auxoutcalls { get; set; }
        public int? IAuxintime { get; set; }
        public int? Auxintime { get; set; }
        public short? Auxincalls { get; set; }
        public int? IOthertime { get; set; }
        public int? IAcdothertime { get; set; }
        public int? Holdtime { get; set; }
        public short? Holdcalls { get; set; }
        public short? Holdabncalls { get; set; }
        public short? Transferred { get; set; }
        public short? Conference { get; set; }
        public short? Abncalls { get; set; }
        public int? Abntime { get; set; }
        public short? Acceptable { get; set; }
        public int? IArrived { get; set; }
        public short? Dequecalls { get; set; }
        public short? Busycalls { get; set; }
        public short? Disccalls { get; set; }
        public short? Outflowcalls { get; set; }
        public int? Anstime { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual HSplit HSplitNavigation { get; set; }
        public virtual HSplit InverseHSplitNavigation { get; set; }
    }
}
