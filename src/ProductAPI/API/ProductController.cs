using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.API.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductService _productService;

        public ProductController(ILogger<ProductController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductResponse> Get()
        {
            return _productService.GetProducts().Select(product => new ProductResponse(product.Uid, product.Name, product.Description, product.Price));
        }

        [HttpGet("{uid}")]
        public ProductResponse GetById(Guid uid)
        {
            var product = _productService.GetProductByUid(uid);

            var (_, name, description, price) = product;

            return new ProductResponse(uid, name, description, price);
        }

        [HttpPost]
        public Guid Post(ProductRequest request)
        {
            var (name, description, price) = request;

            var uid = _productService.CreateProduct(name, description, price);

            return uid;
        }

        [HttpPut("{uid}")]
        public void Put(Guid uid, ProductRequest request)
        {
            var (name, description, price) = request;

            _productService.UpdateProduct(uid, name, description, price);
        }

        [HttpDelete("{uid}")]
        public void Delete(Guid uid)
        {
            _productService.DeleteProduct(uid);
        }
    }
}
