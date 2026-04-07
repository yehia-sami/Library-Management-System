using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerProject.Models;
using SummerProject.Repositories;
using SummerProject.DTOs;

namespace SummerProject.Controllers.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoriesApiController(ICategoryRepository repo)
        {
            _repo = repo;
        }

    

     
       

      
        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public ActionResult<Category> Create(Category category, [FromQuery] int[] bookIds)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    _repo.Add(category, bookIds);

        //   return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        //}

     
        //[HttpPut("{id}")]
        //[Authorize(Roles = "Admin")]
        //public ActionResult Update(int id, Category category, [FromQuery] int[] bookIds)
        //{
        //    if (id != category.Id) return BadRequest();

        //    var existing = _repo.GetById(id);
        //    if (existing == null) return NotFound();

        //   _repo.Update(category, bookIds);

        //   return NoContent();
        //}



        //==============================

        
        [HttpGet]
        [AllowAnonymous] 
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            return Ok(_repo.GetAll());
        }

     
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Category> GetById(int id)
        {
            var category = _repo.GetById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }
      

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<Category> Create([FromBody] CategoryCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var category = new Category
            {
                Name = dto.Name,
                BookCategories = new List<BookCategories>()
            };

            _repo.Add(category, dto.BookIds);

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

     
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, [FromBody] CategoryUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();

            var category = new Category
            {
                Id = dto.Id,
                Name = dto.Name,
                BookCategories = new List<BookCategories>()
            };

            _repo.Update(category, dto.BookIds);

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();

            _repo.Delete(id);
            return NoContent();
        }
    }
}
