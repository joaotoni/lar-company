using TecnicExam.Models;
using System.Collections.Generic;
using System.Linq;

namespace TecnicExam.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {id} not found");
            }
            return product;
        }

        public void Add(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.CategoryId = product.CategoryId;
            }
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
