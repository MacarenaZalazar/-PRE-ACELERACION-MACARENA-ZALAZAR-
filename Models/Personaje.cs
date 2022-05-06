using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemyC.Models
{
    public class Personaje
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Imagen { get; set; }

        public string Historia { get; set; }
        public string Edad { get; set; }
        public string Peso { get; set; }

        public ICollection<Pelicula> Peliculas { get; set; }

    }
}
