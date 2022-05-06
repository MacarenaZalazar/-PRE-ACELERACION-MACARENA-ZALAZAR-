using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeAlkemyC.Models;

namespace ChallengeAlkemyC.Repositories
{
    public interface IPeliculaRepository : IGenericRepository<Pelicula>
    {
        Task<List<Pelicula>> GetAllPeliculas();

    }

}
