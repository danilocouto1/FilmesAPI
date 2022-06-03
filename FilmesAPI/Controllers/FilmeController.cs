using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filmes> listaFilmes = new List<Filmes>();
        private static int id = 1;
        [HttpPost]
        public void Adicionar([FromBody] Filmes addFilmes)
        {
            addFilmes.Codigo = id++;
            listaFilmes.Add(addFilmes);
        }

        [HttpGet]
        public IEnumerable<Filmes> Retornar()
        {
            return listaFilmes;
        }

        [HttpGet("{id}")]
        public Filmes Retornar(int id)
        {
            return listaFilmes.FirstOrDefault(filme => filme.Codigo == id);
        }

    }
}
