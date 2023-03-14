using BusinessObject;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository productRepository = new ProductRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                return productRepository.GetProducts().ToList();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            try
            {
                return productRepository.GetProductByID(id);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpGet("categories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            try
            {
                return productRepository.GetCategories().ToList();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertProduct(Product pro)
        {
            try
            {
                productRepository.InsertProduct(pro);

                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product pro)
        {
            try
            {
                pro.ProductId = id;
                productRepository.UpdateProduct(pro);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                productRepository.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }

        }

        [HttpGet("name")]
        public ActionResult<IEnumerable<Product>> SearchByName ([FromQuery]string searchName)
        {
            try
            {
                var productList = productRepository.GetProductsByName(searchName).ToList();
                return productList;
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }

        }

        [HttpGet("range")]
        public ActionResult<IEnumerable<Product>> SearchByName([FromQuery]string fromPrice, [FromQuery] string toPrice)
        {
            try
            {
                decimal from = Decimal.Parse(fromPrice);
                decimal to = Decimal.Parse(toPrice);
                var productList = productRepository.SearchProductsInPriceRange(from, to).ToList();
                return productList;
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message);
            }

        }
    }
}
