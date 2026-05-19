using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using osztalynaplo.Models;

namespace osztalynaplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JegyController : ControllerBase
    {
        [HttpGet("feladat12")]
        public IActionResult Get4()
        {
            using (var context = new osztalynaploContext())
            {
                try
                {
                    return Ok("Összes jegy száma: " + context.Jegyeks.Count());
                }
                catch (System.Exception ex)
                {
                    return BadRequest(StatusCode(400,"Adatbázis nem elérhető!"));
                }
            }
        }

        [HttpPost("feladat13")]
        public IActionResult Get5(string uid, Jegyek jegyek)
        {
            string userid = "FKB3F4FEA09CE43C";
            using (var context = new osztalynaploContext())
            {
                try
                {
                    if (userid == uid)
                    {
                        context.Jegyeks.Add(jegyek);
                        context.SaveChanges();

                        CreatedAtAction(nameof(TantargyController.Get2), new
                        {
                            id = jegyek.Id
                        }, jegyek);

                        return Ok(StatusCode(201, "Jegy hozzáadása sikeresen megtörtént."));
                    }
                    else
                    {
                        return StatusCode(401, "Nincs jogosultsága új versenyző felvételéhez!");
                    }
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
