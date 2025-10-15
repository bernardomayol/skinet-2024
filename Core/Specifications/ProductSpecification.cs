using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductSpecParams specParams) : base(x =>
        (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
            (specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Brand)) &&
            (specParams.Types.Count == 0 || specParams.Types.Contains(x.Type)) 
        )
        {
            ApplyPaging((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);

            switch (specParams.Sort?.ToLower())
            {
                case "priceasc":
                    AddOrderBy(p => p.Price);
                    break;
                case "pricedesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        }
    }
}
