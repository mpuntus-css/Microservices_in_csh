using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMService.Models;

namespace ProductMService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Product A", Price = 10.99m },
            new Product { Id = 2, Name = "Product B", Price = 20.99m },
        };

        [HttpGet]
        public IEnumerable<Product> GetAll() => Products;

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id) =>
            Products.FirstOrDefault(p => p.Id == id) is Product product
                ? Ok(product)
                : NotFound();

        [HttpPost]
        public ActionResult Add(Product product)
        {
            Products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }


    }
}
