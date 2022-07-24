using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductBrand, s => s.MapFrom(o => o.ProductBrand.Name))
                .ForMember(d => d.ProductType, s => s.MapFrom(o => o.ProductType.Name))
                .ForMember(d => d.ProductSize, s => s.MapFrom(o => o.ProductSize.Name));
        }
    }
}