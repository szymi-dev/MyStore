using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Specifications
{
    public interface ISpecification<T>
    {
        // var id = 1;
        // Where(x => x.id == Id)
        Expression<Func<T, bool>> Criteria { get; }
        // Include(x => x.ProductBrand) for example
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
    }
}