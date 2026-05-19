using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using osztalynaplo.Models;

namespace osztalynaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanarController : ControllerBase
    {
        [HttpGet("feladat11")]
        public IActionResult Get3()
        {
            using (var context = new osztalynaploContext())
            {
                try
                {
                    return Ok(context.Tanaroks.Include(x => x.Jegyeks).ToList());
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
