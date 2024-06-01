using TecnicExam.Models;
using System.Collections.Generic;
using System.Linq;

namespace TecnicExam.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly List<Category> _categories = new();

        public IEnumerable<Category> GetAll()
        {
            return _categories;
        }

        public Category GetById(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with Id {id} not found");
            }
            return category;
        }

        public void Add(Category category)
        {
            category.Id = _categories.Count + 1;
            _categories.Add(category);
        }

        public void Update(Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
            }
        }

        public void Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
