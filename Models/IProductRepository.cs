using System.Collections.Generic;

namespace WebGraduationProject.Models
{
    public interface IProductRepository
    {
        bool SaveChanges();
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int Id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}