using Microsoft.AspNetCore.Mvc;


namespace ChallengeAlkemyC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class PersonajesController : ControllerBase
    {
        //private readonly DisneyContext _context; 

        //GET METHOD
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(5);
        }

        //POST METHOD

    }
}
