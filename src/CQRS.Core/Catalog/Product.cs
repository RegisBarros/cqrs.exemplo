using CQRS.Core.Common;
using System;

namespace CQRS.Core.Catalog
{
    public class Product : Entity
    {
        public Product(string title, string description, string code, Price price, Brand brand, Category category)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Code = code;
            CreatedAt = DateTime.Now;
            Price = price;
            Brand = brand;
            Category = category;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Code { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Price Price { get; private set; }

        public Brand Brand { get; private set; }

        public Category Category { get; private set; }
    }
}
