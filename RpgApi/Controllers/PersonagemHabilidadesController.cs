using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagemHabilidadesController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagemHabilidadesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetByPersonagemId")]
        public async Task<ActionResult<List<PersonagemHabilidade>>> GetByPersonagemId(int personagemId)
        {
            return await _context.TB_PERSONAGENS_HABILIDADES
                .Where(ph => ph.PersonagemId == personagemId)
                .ToListAsync();
        }

        [HttpGet("GetHabilidades")]
        public async Task<ActionResult<List<Habilidade>>> GetHabilidades()
        {
            return await _context.TB_HABILIDADES.ToListAsync();
        }

        [HttpPost("DeletePersonagemHabilidade")]
        public async Task<IActionResult> DeletePersonagemHabilidade(PersonagemHabilidade dados)
        {
            var ph = await _context.TB_PERSONAGENS_HABILIDADES
                .FirstOrDefaultAsync(p => p.PersonagemId == dados.PersonagemId && p.HabilidadeId == dados.HabilidadeId);

            if (ph == null)
                return NotFound("Habilidade não encontrada para esse personagem.");

            _context.TB_PERSONAGENS_HABILIDADES.Remove(ph);
            await _context.SaveChangesAsync();

            return Ok("Habilidade removida com sucesso.");
        }
    }

}
