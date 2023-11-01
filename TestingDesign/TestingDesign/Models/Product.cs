using System;
using System.Collections.Generic;

#nullable disable

namespace TestingDesign.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public int TypeId { get; set; }
        public string ProductImage { get; set; }

        public virtual Category Category { get; set; }
        public virtual ProductUnitType Type { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
