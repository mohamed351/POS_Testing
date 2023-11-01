using System;
using System.Collections.Generic;

#nullable disable

namespace TestingDesign.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gpc { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
