using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordString { get; set; }
        public string Perfil {  get; set; }
        public string token {  get; set; }

        public byte[]? Foto { get; set; }
        public string email {  get; set; } 
        public double? Latitude { get; set; }
        public double? Longitude { get; set; } 

    }
}
