using System;

namespace FilmesAPI.Data.DTOs
{
    public class ReadFilmeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public DateTime consulta { get; set; }
    }
}
