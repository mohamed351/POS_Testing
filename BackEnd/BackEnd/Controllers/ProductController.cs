using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly POSApplicaticationContext pOSApplicaticationContext;

        public ProductController(POSApplicaticationContext pOSApplicaticationContext)
        {
            this.pOSApplicaticationContext = pOSApplicaticationContext;
        }
        [HttpGet]
        public IActionResult GetProduct()
        {
         var query =   pOSApplicaticationContext.Products
                  .Include(a => a.Type)
                  .Include(a=> a.Category)
                .Include(a => a.ProductDetails)
                .ThenInclude(a => a.Package)
                .Select(a=> new
                {
                    a.Id , 
                    a.ProductName ,
                    Details = a.ProductDetails.Select(a=> new {a.ProductId , a.ProductName , a.SalesPrice , a.Package.PackageName , a.PackageId , a.Quantity , a.QuantityBase , a.ParentPackageId}).ToList(),
                    TypeName = a.Type.TypeName,
                    Category = a.Category.Name
                }).ToList();
            return Ok(query);
        }
    }
}
