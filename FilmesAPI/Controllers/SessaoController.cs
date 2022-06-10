using AutoMapper;
using FilmesApi.Data.Dtos.Sessao;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private DBContext _context;
        private IMapper _mapper;

        public SessaoController(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            Sessao sessao= _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

                return Ok(sessaoDto);
            }
            return NotFound();
        }
    }
}
