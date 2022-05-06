using ChallengeAlkemyC.Models;
using ChallengeAlkemyC.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChallengeAlkemyC.Controllers
{
    [ApiController]
    [Route("api/character")]


    public class CharactersController : Controller
    {
        private readonly IPersonajeRepository _context;

        public CharactersController(IPersonajeRepository personajeRepository)
        {
            _context = personajeRepository;
        }

        //GET METHOD
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _context.GetAllPersonajes();
                return Ok(list);

            }
            catch
            {
                return BadRequest("Error: No se pudieron traer los personajes");

            }
            
        }
        //GET METHOD
        [HttpGet]
        [Route("filter")]
        public IActionResult GetByQueries(string name, int age, int weight, int movie)
        {
            try
            {
                var character =  _context.GetByQuery(name, age, weight, movie);
                return Ok(character);

            }
            catch
            {
                return BadRequest("Error: No se pudieron traer los personajes");

            }

        }

        //POST METHOD
        [HttpPost]
        public IActionResult Post(Personaje personaje)
        {
            try
            {
               // _context.Add(personaje);
                return Ok(_context);

            }
            catch
            {
                return BadRequest("Error: No se pudo agregar el personaje enviado");
            }
        }

        [HttpPut]

        public IActionResult Put(Personaje personaje)
        {
            int IdP = personaje.Id;
           
            //var personajeToUpdate = _context.Personajes.ToList().Find(x => x.Id == IdP);
            //if(!personajeToUpdate) return BadRequest("El personaje enviado no existe.");
            //personajeToUpdate.Imagen = personaje.Imagen;
            //personajeToUpdate.Historia = personaje.Historia;
            //personajeToUpdate.Peso = personaje.Peso;
            //personajeToUpdate.Edad = personaje.Edad;
            //personajeToUpdate.Nombre = personaje.Nombre;

            return Ok(_context);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete()
        {

            return Ok();
        }

    }
}
