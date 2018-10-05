using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Dto;
using Services.Interfaces;

namespace ProductCatalogApplication.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET api/product
        [HttpGet]
        public IEnumerable<ProductDto> Get(string searchText = null)
        {
            return productService.GetAll();
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            return productService.GetById(id);
        }

        // POST api/product
        [HttpPost]
        public void Post([FromBody]ProductDto productDto)
        {
            productService.Add(productDto);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ProductDto productDto)
        {
            productService.Update(productDto);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productService.Delete(id);
        }
    }
}
