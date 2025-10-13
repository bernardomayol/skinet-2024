﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(string? brand, string? type, string? sort) : base(x =>
            (string.IsNullOrEmpty(brand) || x.Brand == brand) &&
            (string.IsNullOrEmpty(type) || x.Type == type))
        {
            switch (sort?.ToLower())
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
