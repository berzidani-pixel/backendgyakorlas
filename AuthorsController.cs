using Farkas_Zoltán_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farkas_Zoltán_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        [HttpGet("feladat9")]
        public ActionResult GetAuthorsBooks(string author)
        {
            try
            {
                using (var context = new LibrarydbContext())
                {
                    var authors = context.Authors
                        .Include(x => x.Books)
                        .Where(a => a.AuthorName == author).ToList();

                    if(authors!= null)
                    {
                        return Ok(authors);
                    }

                    return NotFound();
                    
                }
                  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("feladat12")]
        public ActionResult NumberOfAuthors()
        {
            try
            {
                using (var context = new LibrarydbContext())
                {
                    var authors = context.Authors.Count();
                       

                    if (authors != null)
                    {
                        return Ok(new { Szerzők_száma = authors});
                    }

                    return NotFound();

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
