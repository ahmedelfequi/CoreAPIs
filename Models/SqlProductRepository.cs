using System.Collections.Generic;
using System.Linq;

namespace WebGraduationProject.Models
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        public SqlProductRepository(AppDbContext context)
        {
            this.context = context;

        }

        // Return all the products (Read)
        // IEnumerable Interface loops through the products in the DbSet.
        public IEnumerable<Product> GetAllProducts()
        {
            return this.context.products.ToList();
        }

        public Product GetProductById(int Id)
        {
            // Product product = this.context.products.Find(Id);
            Product product = this.context.products.FirstOrDefault(p => p.productID == Id);

            return product;
        }

        // Add a new product (Create)
        public void AddProduct(Product product)
        {
            this.context.products.Add(product);
        }

        public bool SaveChanges()
        {
            this.context.SaveChanges();

            return (this.context.SaveChanges() >= 0);
        }

        public void UpdateProduct(Product product)
        {
            
        }

        public void DeleteProduct(Product product)
        {
            context.products.Remove(product);
        }
    }
}