using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemyC.Models
{
    public class Pelicula
    {
        [Key]
        public int IPelicula { get; set; }
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Calificacion { get; set; }

        //relacion de uno a muchos

        public Personaje Personajes { get; set; }
    }
}
