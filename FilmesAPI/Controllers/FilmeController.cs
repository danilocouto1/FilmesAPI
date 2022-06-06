using AutoMapper;
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
        private DBContext _context;
        private IMapper _mapper;

        public FilmeController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpPost]
        public IActionResult Adicionar([FromBody] CreateFilmeDto filmeDto)
        {
            Filme addFilme = _mapper.Map<Filme>(filmeDto);

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
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
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
            _mapper.Map(filmeDto, filme);
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
