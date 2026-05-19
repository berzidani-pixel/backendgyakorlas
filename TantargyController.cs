using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using osztalynaplo.Models;

namespace osztalynaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TantargyController : ControllerBase
    {
        [HttpGet("feladat9")]
        public IActionResult Get()
        {
            using (var context = new osztalynaploContext())
            {
                try
                {
                    return Ok(context.Tantargyaks.ToList());
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet("feladat10")]
        public IActionResult Get2(string tantargy)
        {
            using (var context = new osztalynaploContext())
            {
                try
                {
                    return Ok(context.Tantargyaks.Where(n => n.TantargyNev == tantargy).Include(x => x.Jegyeks).ToList());
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
