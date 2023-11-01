using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Models
{
    public partial class ProductUnitType
    {
        public ProductUnitType()
        {
            Products = new HashSet<Product>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
