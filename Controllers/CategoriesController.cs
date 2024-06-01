using Microsoft.AspNetCore.Mvc;
using TecnicExam.Models;
using TecnicExam.Services;
using System.Collections.Generic;

namespace TecnicExam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        [HttpPost]
        public ActionResult<Category> Post(Category category)
        {
            _categoryService.Add(category);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Category updatedCategory)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            updatedCategory.Id = id;
            _categoryService.Update(updatedCategory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.Delete(id);
            return NoContent();
        }
    }
}
