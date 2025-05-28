using Microsoft.AspNetCore.Mvc;

namespace day03.Controllers
{
    using day03.Model;
    using day03.Services;
    using Microsoft.AspNetCore.Mvc;

    
        [ApiController]
        [Route("api/[controller]")]
        public class BooksController : ControllerBase
        {
            private readonly BookService _bookService;

            public BooksController(BookService bookService)
            {
                _bookService = bookService;
            }



            [HttpPost("CreateBooks")]
            public IActionResult Create(Book book)
            {
                _bookService.Add(book);
                return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
            }


            [HttpGet("BookGetbyId")]
            public ActionResult<Book> GetById(int id)
            {
                var book = _bookService.GetById(id);
                return book is null ? NotFound() : Ok(book);
            }

            [HttpPut("UpdateBooks")]
            public IActionResult Update(int id, Book book)
            {
                var existing = _bookService.GetById(id);
                if (existing is null) return NotFound();

                _bookService.Update(id, book);
                return NoContent();
            }

            [HttpDelete("DeleteBooks")]
            public IActionResult Delete(int id)
            {
                var existing = _bookService.GetById(id);
                if (existing is null) return NotFound();

                _bookService.Delete(id);
                return NoContent();
            }
        }
    }


