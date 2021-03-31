using BooksManagement.Models;
using BooksManagement.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepositorie _bookRepositorie;
        public BooksController(IBookRepositorie bookRepositorie)
        {
            _bookRepositorie = bookRepositorie;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepositorie.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepositorie.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book Book)
        {
            var newBook = await _bookRepositorie.Creat(Book);
            return CreatedAtAction(nameof(GetBooks) , new {id = newBook.id} , newBook);
        }

        [HttpPut]
        public async Task<ActionResult<Book>> PutBook(int id , [FromBody] Book Book)
        {
            if(id != Book.id)
            {
                return BadRequest();
            }
            await _bookRepositorie.Update(Book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookRepositorie.Delete(id);
            return NoContent();
        }
    }
}
