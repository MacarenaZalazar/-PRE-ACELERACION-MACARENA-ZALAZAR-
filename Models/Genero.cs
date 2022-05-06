using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemyC.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Imagen { get; set; }
        //relacion de uno  a muchos

        public Pelicula Peliculas { get; set; }
    }
}
