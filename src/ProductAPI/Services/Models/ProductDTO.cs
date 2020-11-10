using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.Models
{
    public record ProductDTO(Guid Uid, string Name, string Description, decimal Price);
}
