using Farkas_Zoltán_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farkas_Zoltán_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("feladat11")]
        public ActionResult GetCategoriesBooks()
        {
            try
            {
                using (var context = new LibrarydbContext())
                {
                    var category = context.Categories
                        .Include(x => x.Books).ToList();


                    if (category != null)
                    {
                        return Ok(category);
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
