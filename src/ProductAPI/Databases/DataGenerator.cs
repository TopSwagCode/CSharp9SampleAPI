using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Databases.Models;

namespace WebApplication1.Databases
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>();
            using var context = new AppDbContext(options);
            if (context.Products.Any())
            {
                return;   // Data was already seeded
            }

            context.Products.AddRange(new Product(Guid.NewGuid(), "Awesome", "", 100.2m));

            context.SaveChanges();
        }
    }
}
