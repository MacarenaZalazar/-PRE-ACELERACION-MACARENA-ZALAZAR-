using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeAlkemyC.Models;

namespace ChallengeAlkemyC.Repositories
{
    public interface IPersonajeRepository : IGenericRepository<Personaje>
    {
        Task<List<Personaje>> GetAllPersonajes();
        IQueryable<Personaje> GetPersonajeDetails();
        IQueryable<Personaje> GetByQuery(string name, int age, int weight, int movieId);


    }

}
