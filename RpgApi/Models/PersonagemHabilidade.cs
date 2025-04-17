using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RpgApi.Models
{
    public class PersonagemHabilidade
    {
        public int PersonagemId { get; set; }
        [JsonIgnore]
        public Personagem? Personagem { get; set; }=null!;
        public int HabilidadeId { get; set; }
        [JsonIgnore]
        public Habilidade? Habilidade { get; set; }=null!;
    }
}