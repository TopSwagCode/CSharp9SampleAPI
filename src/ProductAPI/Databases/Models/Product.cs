using System;

namespace ProductAPI.Databases.Models
{
    public record Product(Guid Uid, string Name, string Description, decimal Price);
}
