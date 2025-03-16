using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("api/personagens")]
    public class PersonagensExercicioController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByName(string nome)
        {
            var personagem = personagens.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    
            if (personagem == null)
                return NotFound("Personagem não encontrado.");
    
            return Ok(personagem);
        }
        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago()
        {
            var lista = personagens
                .Where(p => p.Classe != ClasseEnum.Cavaleiro) 
                .OrderByDescending(p => p.PontosVida) 
                .ToList();

            return Ok(lista);
        }
        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            var quantidade = personagens.Count; 
            var soma = personagens.Sum(p => p.Inteligencia); 

            var resultado = new
            {
                QuantidadePersonagens = quantidade,
                SomaInteligencia = soma
            };

            return Ok(resultado);
        }

        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem novoPersonagem)
        {
            if (novoPersonagem.Defesa < 10 || novoPersonagem.Inteligencia > 30)
            {
                return BadRequest("a defesa não pode ser menor que 10 e a inteligência não pode ser maior que 30.");
            }
            personagens.Add(novoPersonagem);

            return Ok(novoPersonagem);
        }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem novoPersonagem)
        {
            if (novoPersonagem.Classe == ClasseEnum.Mago && novoPersonagem.Inteligencia < 35)
            {
                return BadRequest("um personagem do tipo mago deve ter inteligência maior ou igual a 35.");
            }
            personagens.Add(novoPersonagem);

            return Ok(novoPersonagem);
        }


        [HttpGet("GetByClasse/{classeId}")]
        public IActionResult GetByClasse(int classeId)
        {
            var personagensFiltrados = personagens.Where(p => (int)p.Classe == classeId).ToList();

            if (personagensFiltrados.Count == 0)
            {
                return NotFound("Nenhum personagem encontrado para essa classe.");
            }

            return Ok(personagensFiltrados);
        }

       
    }
}