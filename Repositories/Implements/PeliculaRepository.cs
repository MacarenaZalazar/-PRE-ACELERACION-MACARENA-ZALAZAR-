using ChallengeAlkemyC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemyC.Repositories.Implements
{

    public class PeliculaRepository : GenericRepository<Pelicula>, IPeliculaRepository
    {
        private DisneyContext _disneyContext;
        public PeliculaRepository(DisneyContext disneyContext) : base(disneyContext)
        {
            this._disneyContext = disneyContext;
        }

        public async Task<List<Pelicula>> GetAllPeliculas()
        {
            return await _disneyContext.Peliculas.ToListAsync();
        }


    }
}