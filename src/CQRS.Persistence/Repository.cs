using CQRS.Core.Catalog;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.Persistence
{
    public class Repository
    {
        private static List<Product> Products { get; set; } = new List<Product>();
        private static List<Brand> Brands { get; set; }
        private static List<Category> Categories { get; set; }

        public Repository()
        {
            Seed();
        }

        public void Add(Product product)
        {
            Products.Add(product);
        }

        public void Update(Product product)
        {
            var old = Get(product.Code);

            old = product;
        }

        public IEnumerable<Product> Get() => Products;

        public Product Get(string code) => Products.FirstOrDefault(p => p.Code == code);

        public Brand GetBrand(string code) => Brands.FirstOrDefault(b => b.Code == code);

        public Category GetCategory(string code) => Categories.FirstOrDefault(c => c.Code == code);

        public void Delete(string code)
        {
            var product = Get(code);

            Products.Remove(product);
        }

        private void Seed()
        {
            Brands = new List<Brand>
            {
                new Brand("Nike", "0001"),
                new Brand("Adidas", "0002"),
                new Brand("Sony", "0003"),
                new Brand("Apple", "0004"),
                new Brand("Microsoft", "0005"),
            };


            Categories = new List<Category>
            {
                new Category("Men's Fashion", "0001"),
                new Category("Women's Fashion", "0002"),
                new Category("Games", "0003"),
                new Category("Software", "0004"),
                new Category("Eletronics", "0005"),
            };
        }
    }
}
