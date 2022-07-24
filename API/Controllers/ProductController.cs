using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using API.Specifications;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts(string sort, int? typeId, int? brandId, int? sizeId)
        {
            var spec = new ProductWithTypesAndBrandsAndSizesSpec(sort, typeId, brandId, sizeId);

            var products = await _productRepo.ListAsync(spec);

            return Ok(_mapper.Map<List<Product>, List<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsAndSizesSpec(id);

            var product = await _productRepo.GetEntity(spec);

            return  _mapper.Map<Product, ProductDto>(product);
        }
    }
}