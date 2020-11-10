using System;

namespace WebApplication1.Databases.Models
{
    public record Product(Guid Uid, string Name, string Description, decimal Price);
}
