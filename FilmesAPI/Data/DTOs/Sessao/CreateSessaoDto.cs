using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Dtos.Sessao
{
    public class CreateSessaoDto
    {
        public int CinemaFK { get; set; }
        public int FilmeFK { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
