using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Filme Filme { get; set; }
        public virtual Cinema Cinema { get; set; }
        public int CinemaFK { get; set; }
        public int FilmeFk { get; set; }
        public DateTime Horario { get; set; }
    }
}
