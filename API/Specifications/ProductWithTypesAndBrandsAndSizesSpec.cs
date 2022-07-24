using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Entities;

namespace API.Specifications
{
    public class ProductWithTypesAndBrandsAndSizesSpec : Specification<Product>
    {
        public ProductWithTypesAndBrandsAndSizesSpec(string sort, int? typeId, int? brandId, int? sizeId) 
            : base(x => (!brandId.HasValue || x.ProductBrandId == brandId) && (!typeId.HasValue || x.ProductTypeId == typeId) 
            && (!sizeId.HasValue || x.ProductSizeId == sizeId))
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductSize);
            AddOrderBy(x => x.Name);

            if(!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductWithTypesAndBrandsAndSizesSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductSize);
        }
    }
}