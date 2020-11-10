using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.API.Models
{
    public record ProductResponse(Guid Uid, string Name, string Description, decimal Price);
}
