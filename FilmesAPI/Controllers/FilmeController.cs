using FilmesAPI.Data;
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
        private FilmeContetx _context;

        public FilmeController(FilmeContetx context)
        {
            _context = context;
        }

        
        [HttpPost]
        public IActionResult Adicionar([FromBody] Filme addFilme)
        {
            _context.Filmes.Add(addFilme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Retornar), new {ID = addFilme.Codigo}, addFilme);
        }

        [HttpGet]
        public IEnumerable<Filme> Retornar()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult Retornar(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Codigo == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Filme filmeAtt)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Codigo == id);
            if (filme == null)
            {
                return NotFound();
            }
            filme.Nome = filmeAtt.Nome;
            filme.Genero = filmeAtt.Genero;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
