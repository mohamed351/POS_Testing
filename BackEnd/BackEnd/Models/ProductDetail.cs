using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Models
{
    public partial class ProductDetail
    {
        public int ProductId { get; set; }
        public int PackageId { get; set; }
        public string ProductName { get; set; }
        public decimal? Quantity { get; set; }
        public string CodeType { get; set; }
        public int? ParentPackageId { get; set; }
        public decimal? QuantityBase { get; set; }
        public string Code { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? Cost { get; set; }
        public bool? IsMain { get; set; }

        public virtual Package Package { get; set; }
        public virtual Product Product { get; set; }
    }
}
