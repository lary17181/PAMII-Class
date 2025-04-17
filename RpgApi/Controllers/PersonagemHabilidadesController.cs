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

        [HttpGet("GetByPersonagemId/{PersonagemId}")]
        public async Task<ActionResult<List<PersonagemHabilidade>>> GetByPersonagemId(int personagemId)
        {
        var habilidades = await _context.TB_PERSONAGENS_HABILIDADES
            .Where(ph => ph.PersonagemId == personagemId)
            .Include(ph => ph.Habilidade)
            .Select(ph => ph.Habilidade)
            .ToListAsync();

    return Ok(habilidades);
        }

        [HttpGet("GetHabilidades")]
        public async Task<ActionResult<List<Habilidade>>> GetHabilidades()
        {
            return await _context.TB_HABILIDADES.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade)
        {
            try{
            Personagem personagem = await _context.TB_PERSONAGENS
                .Include(p => p.Arma)
                .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

                if (personagem == null)
                throw new System.Exception("Personagem não encontrado para o Id Informado.");


            Habilidade habilidade = await _context.TB_HABILIDADES
                                .FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);
            if(habilidade == null)
                throw new System.Exception("Habilidade não encontrada");

            
            PersonagemHabilidade ph = new PersonagemHabilidade();
            ph.Personagem = personagem;
            ph.Habilidade = habilidade;
            await _context.TB_PERSONAGENS_HABILIDADES.AddAsync(ph);
            int linhasAfetadas = await _context.SaveChangesAsync();

            return Ok(linhasAfetadas);

            }
            catch(SystemException ex)
            {
                return BadRequest(ex.Message);
            }

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
