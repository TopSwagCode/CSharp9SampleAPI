using AutoMapper;
using System;
using ProductAPI.Services.Models;

namespace ProductAPI.API.Models
{
    public record ProductResponse(Guid Uid, string Name, string Description, decimal Price);


    public class ProductResponseMappingProfile : Profile
    {
        public ProductResponseMappingProfile()
        {
            CreateMap<ProductDTO, ProductResponse>();
        }
    }
}
