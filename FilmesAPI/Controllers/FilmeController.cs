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
        private static List<Filme> listaFilmes = new List<Filme>();
        private static int id = 1;
        [HttpPost]
        public IActionResult Adicionar([FromBody] Filme addFilme)
        {
            addFilme.Codigo = id++;
            listaFilmes.Add(addFilme);
            return CreatedAtAction(nameof(Retornar), new {ID = addFilme.Codigo}, addFilme);
        }

        [HttpGet]
        public IActionResult Retornar()
        {
            return Ok(listaFilmes);
        }

        [HttpGet("{id}")]
        public IActionResult Retornar(int id)
        {
            Filme filme = listaFilmes.FirstOrDefault(filme => filme.Codigo == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }

    }
}
