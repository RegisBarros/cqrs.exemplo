using CQRS.Core.Catalog;
using System;

namespace CQRS.Application.Catalog.Queries.GetProduct
{
    public class ProductResponse
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public DateTime CreatedAt { get; set; }

        public PriceResponse Price { get; set; }

        public BrandResponse Brand { get; set; }

        public CategoryResponse Category { get; set; }

        public class Mapper
        {
            public static ProductResponse ToResponse(Product product)
            {
                return new ProductResponse
                {
                    Title = product.Title,
                    Code = product.Code,
                    CreatedAt = product.CreatedAt,
                    Description = product.Description,
                    Brand = new BrandResponse
                    {
                        Code = product.Brand.Code,
                        Name = product.Brand.Name
                    },
                    Category = new CategoryResponse
                    {
                        Code = product.Category.Code,
                        Name = product.Category.Name
                    },
                    Price = new PriceResponse
                    {
                        Current = product.Price.Current,
                        Old = product.Price.Old
                    }
                };
            }
        }
    }

    public class CategoryResponse
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    public class BrandResponse
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    public class PriceResponse
    {
        public decimal Old { get; set; }
        public decimal Current { get; set; }
    }
}