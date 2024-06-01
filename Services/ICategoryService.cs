using TecnicExam.Models;
using System.Collections.Generic;

namespace TecnicExam.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
