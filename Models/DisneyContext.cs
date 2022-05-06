using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemyC.Models
{
    public class DisneyContext : DbContext
    {

        public DisneyContext(DbContextOptions<DisneyContext> options) : base(options)
        {
            // optionsBuilder.UseSqlServer("Server=DESKTOP-9FQDEKD\\SQLEXPRESS; Database=Disney;Trusted_Connection=True;");
        }
        //entities
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}
