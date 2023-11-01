using System;
using System.Collections.Generic;

#nullable disable

namespace TestingDesign.Models
{
    public partial class Package
    {
        public Package()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int Id { get; set; }
        public string PackageName { get; set; }
        public int? TypeId { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
