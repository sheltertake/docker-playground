using System.Linq;

namespace mvc {
    public class Product {
        public Product () { }
        public Product (string name = null,
            string category = null,
            decimal price = 0) {
            Name = name;
            Category = category;
            Price = price;
        }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public interface IRepository {
        IQueryable<Product> Products { get; }
    }

    public class DummyRepository : IRepository {
        private static Product[] DummyData = new Product[] {
            new Product { Name = "Prod1", Category = "Cat1", Price = 100 },
            new Product { Name = "Prod2", Category = "Cat1", Price = 100 },
            new Product { Name = "Prod3", Category = "Cat2", Price = 100 },
            new Product { Name = "Prod4", Category = "Cat2", Price = 100 },
        };
        public IQueryable<Product> Products => DummyData.AsQueryable ();
    }
}