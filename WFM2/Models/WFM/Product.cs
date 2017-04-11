using System;
using System.Collections.Generic;

namespace WFM2.Models.WFM
{
    public partial class Product
    {
        public Product()
        {
            Units = new HashSet<Units>();
        }

        public int Id { get; set; }
        public int? CatId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Units> Units { get; set; }
        public virtual ProductCategory Cat { get; set; }
    }
}
