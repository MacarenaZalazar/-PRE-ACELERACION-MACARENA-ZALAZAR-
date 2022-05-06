using ChallengeAlkemyC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemyC.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class PeliculaController : Controller
    {
        private readonly IPeliculaRepository _context;

        public PeliculaController(IPeliculaRepository peliculaRepository)
        {
            _context = peliculaRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _context.GetAllPeliculas();
                return Ok(list);

            }
            catch
            {
                return BadRequest("Error: No se pudieron traer las películas");

            }

        }
    }
}
