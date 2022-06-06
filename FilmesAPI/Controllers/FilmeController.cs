using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
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
        public IActionResult Adicionar([FromBody] CreateFilmeDto filmeDto)
        {
            Filme addFilme = new Filme
            { 
                Nome = filmeDto.Nome,
                Genero = filmeDto.Genero,
            };

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
                ReadFilmeDto filmeDto = new ReadFilmeDto
                {
                    Nome = filme.Nome,
                    Genero = filme.Genero,
                    consulta = DateTime.Now
                };
                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Codigo == id);
            if (filme == null)
            {
                return NotFound();
            }
            filme.Nome = filmeDto.Nome;
            filme.Genero = filmeDto.Genero;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Codigo == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
