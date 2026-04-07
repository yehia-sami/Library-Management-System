using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerProject.Models;
using SummerProject.Repositories;
using System.Collections.Generic;

namespace SummerProject.Controllers.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        private readonly IBookRepository _repo;
        public BooksApiController(IBookRepository repo) => _repo = repo;

        [HttpGet]
        [Authorize]
        public ActionResult<List<Book>> GetAll() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Book> GetById(int id)
        {
            var book = _repo.GetById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] 
        public ActionResult<Book> Create(Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _repo.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update(int id, Book book)
        {
            if (id != book.Id) return BadRequest();
            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();
            _repo.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] 
        public ActionResult Delete(int id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();
            _repo.Delete(id);
            return NoContent();
        }
    }
}
