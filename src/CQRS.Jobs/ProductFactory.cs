using Bogus;
using CQRS.Application.Catalog.Commands;
using System;

namespace CQRS.Jobs
{
    public class ProductFactory
    {
        private static readonly Faker<CreateProductCommand> faker;

        static ProductFactory()
        {
            var randomizer = new Randomizer();

            faker = new Faker<CreateProductCommand>()
                .RuleFor(product => product.Title, faker => faker.Commerce.Product())
                .RuleFor(product => product.Brand, faker => faker.Company.CompanyName())
                .RuleFor(product => product.Category, faker => faker.Commerce.Department())
                .RuleFor(product => product.Code, faker => faker.Commerce.Ean13())
                .RuleFor(product => product.Description, faker => faker.Commerce.ProductName())
                .RuleFor(product => product.OldPrice, faker => Convert.ToDecimal(faker.Commerce.Price(1, 100, 2)))
                .RuleFor(product => product.Price, faker => Convert.ToDecimal(faker.Commerce.Price(100, 1000, 2)));
        }

        internal static CreateProductCommand Generate()
        {
            return faker.Generate();
        }
    }
}
