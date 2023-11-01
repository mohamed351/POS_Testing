using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingDesign.Models;

namespace TestingDesign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly POSApplicaticationContext context;

        public ProductsController(POSApplicaticationContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var product = context.Products
               .Include(a => a.ProductDetails)
               .Select(a => new { a.Id, a.ProductName, Details = a.ProductDetails.Select(a => new { a.Id, a.ProductName, a.ParentId, a.Quantity, a.SalesPrice , a.Cost , a.CodeType , a.Code }) });

            return Ok(product);
        }
        [HttpGet("{id?}")]
        public IActionResult GetProductByID(int? id)
        {
            var product = context.Products
           .Include(a => a.ProductDetails)
           .Select(a => new {a.Id , a.ProductName, Details = a.ProductDetails.Select(a => new { a.Id, a.ProductName, a.ParentId, a.Quantity, a.QuantityBase , a.SalesPrice, a.Cost  ,a.CodeType , a.Code }) })
            .FirstOrDefault(a=> a.Id == id);

            return Ok(product);
            
        }
    }
}
