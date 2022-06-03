using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContetx : DbContext
    {
        public FilmeContetx(DbContextOptions<FilmeContetx> options) : base(options)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
