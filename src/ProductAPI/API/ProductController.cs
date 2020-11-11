using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.API.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger, ProductService productService, IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ProductResponse> Get()
        {
            var products = _productService.GetProducts();

            var productsResponse = _mapper.Map<IEnumerable<ProductResponse>>(products);

            return productsResponse;
        }

        [HttpGet("{uid}")]
        public ProductResponse GetById(Guid uid)
        {
            var product = _productService.GetProductByUid(uid);

            var productResponse = _mapper.Map<ProductResponse>(product);

            return productResponse;
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
