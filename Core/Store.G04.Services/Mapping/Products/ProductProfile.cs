using AutoMapper;
using Store.G04.Domain.Entities.Products;
using Store.G04.Shared.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Services.Mapping.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(D => D.Brand, O => O.MapFrom(src => src.Brand.Name))
                .ForMember(D => D.Type, O => O.MapFrom(src => src.Type.Name));

            CreateMap<ProductBrand, ProductResponse>();

            CreateMap<ProductType, ProductResponse>();


        }
    }
}