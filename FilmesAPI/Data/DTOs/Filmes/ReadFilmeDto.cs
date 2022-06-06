using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class ReadFilmeDto
    {

        [Required(ErrorMessage = "Nome Obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Genero Obrigatorio")]
        public string Genero { get; set; }

        public DateTime consulta { get; set; }
    }
}
