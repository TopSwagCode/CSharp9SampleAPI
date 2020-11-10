using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Databases;
using WebApplication1.Databases.Models;
using WebApplication1.Services.Models;

namespace WebApplication1.Services
{
    public class ProductService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<ProductService> _logger;

        public ProductService(AppDbContext appDbContext, ILogger<ProductService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return _appDbContext.Products.Select(product => new ProductDTO(product.Uid, product.Name, product.Description, product.Price));
        }

        public ProductDTO GetProductByUid(Guid uid)
        {
            var product = _appDbContext.Products.AsNoTracking().FirstOrDefault(product => product.Uid == uid);

            if (product == null) throw new KeyNotFoundException($"Unable to find product with Uid: {uid}");

            var (_, name, description, price) = product;

            return new ProductDTO(uid, name, description, price);
        }

        public Guid CreateProduct(string name,string description, decimal price)
        {
            var uid = Guid.NewGuid();
            _appDbContext.Products.Add(new Product(uid, name, description, price));
            _appDbContext.SaveChanges();

            return uid;
        }

        public void UpdateProduct(Guid uid, string name, string description, decimal price)
        {
            var product = _appDbContext.Products.AsNoTracking().FirstOrDefault(x => x.Uid == uid);

            if (product == null) throw new KeyNotFoundException($"Unable to find product with Uid: {uid}");

            var updateProduct = product with 
            { 
                Name = name,
                Description = description,
                Price  = price
            };

            if(product == updateProduct)
            {
                _logger.LogInformation($"Trying to update product with no changes with Uid: {uid}");
            }

            _appDbContext.Update(updateProduct);
            _appDbContext.SaveChanges();
        }

        public void DeleteProduct(Guid uid)
        {
            var product = _appDbContext.Products.AsNoTracking().FirstOrDefault(x => x.Uid == uid);

            if (product == null) throw new KeyNotFoundException($"Unable to find product with Uid: {uid}");

            _appDbContext.Remove(product);
            _appDbContext.SaveChanges();
        }
    }

    
}
