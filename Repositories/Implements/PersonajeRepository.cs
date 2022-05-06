using ChallengeAlkemyC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemyC.Repositories.Implements
{

    public class PersonajeRepository : GenericRepository<Personaje>, IPersonajeRepository
    {
        private DisneyContext _disneyContext;
        public PersonajeRepository(DisneyContext disneyContext) : base(disneyContext)
        {
            this._disneyContext = disneyContext;
        }

        public async Task<List<Personaje>> GetAllPersonajes()
        {
            return await _disneyContext.Personajes.ToListAsync();
        }
 
        public IQueryable<Personaje> GetPersonajeDetails()
        {
            return _disneyContext.Personajes.Include(a => a.Peliculas)
                                                .ThenInclude(a => a.Generos);
        }

        public IQueryable<Personaje> GetByQuery(string name, int age, int weight, int movieId)
        {
            var query = _disneyContext.Personajes
                .Include(x => x.Peliculas)
                    .ThenInclude(g => g.Generos)
                        .Where(x => x.Nombre.Contains(name) || x.Edad == age
                                || x.Peso == weight
                                || x.Peliculas.Any(i => i.IPelicula == movieId))
                                    .Select(c => new Personaje
                                    {
                                        Imagen = c.Imagen,
                                        Nombre = c.Nombre,
                                        Edad = c.Edad,
                                        Peso = c.Peso,
                                        Historia = c.Historia,
                                        Peliculas = c.Peliculas
                                    });

            return query;
        }

        public async Task<Personaje> PostPersonaje(Personaje item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(Personaje));
            var personaje = item;
            await _disneyContext.Set<Personaje>().AddAsync(personaje);
            await _disneyContext.SaveChangesAsync();
            return personaje;
        }


    }
}