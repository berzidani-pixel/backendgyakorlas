using Farkas_Zoltán_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Farkas_Zoltán_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("feladat10")]
        public ActionResult GetAllBooks()
        {
            try
            {
                using (var context = new LibrarydbContext())
                {
                    var books = context.Books.ToList();
                       

                    if (books != null)
                    {
                        return Ok(books);
                    }

                    return NotFound();

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("feladat13")]
        public async Task<ActionResult> AddNewBook(string UID, Book book)
        {
            string id = "FKB3F4FEA09CE43C";
            try
            {
                if(id == UID)
                {
                    using (var context = new LibrarydbContext())
                    {
                        var newBook = new Book
                        {
                            Title = book.Title,
                            PublishDate = DateTime.Now,
                            AuthorId = book.AuthorId,
                            CategoryId = book.CategoryId
                        };

                        if (newBook != null)
                        {
                            await context.Books.AddAsync(newBook);
                            await context.SaveChangesAsync();

                            return StatusCode(201, new { message = "Könyv hozzáadása sikeresen megtörtént." });
                        }

                        return NotFound();
                    }
                }

                return StatusCode(401, new { message = "Nincs jogosultdága új könyv felvételéhez."});

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("feladat16")]
        public ActionResult UpdateBook(int id, Book book) 
        {
            try
            {
                using (var context = new LibrarydbContext())
                {
                    var existingBook = context.Books.FirstOrDefault(x=> x.BookId == id);

                    if(existingBook != null)
                    {
                        existingBook.Title = book.Title;
                        existingBook.AuthorId = book.AuthorId;
                        existingBook.CategoryId = book.CategoryId;

                        context.Books.Update(existingBook);
                        context.SaveChanges();

                        return Ok(existingBook);
                    }
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
