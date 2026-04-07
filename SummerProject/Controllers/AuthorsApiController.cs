using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerProject.Models;
using SummerProject.Repositories;
using System.Collections.Generic;

namespace SummerProject.Controllers.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthorsApiController : ControllerBase
    {
        private readonly IAuthorRepository _repo;
        public AuthorsApiController(IAuthorRepository repo) => _repo = repo;

        [HttpGet]
        [Authorize]
        public ActionResult<List<Author>> GetAll() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Author> GetById(int id)
        {
            var author = _repo.GetById(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<Author> Create(Author author)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _repo.Add(author);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update(int id, Author author)
        {
            if (id != author.Id) return BadRequest();
            var existing = _repo.GetById(id);
            if (existing == null) return NotFound();
            _repo.Update(author);
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
