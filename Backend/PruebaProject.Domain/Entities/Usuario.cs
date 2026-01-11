using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaProject.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }

        [JsonIgnore]
        public Persona? Persona { get; set; }

        // Constructor vacio
        public Usuario() { }

        // Constructor con parametros
        public Usuario(int personaId, string nombreUsuario, string pass, DateTime fechaCreacion)
        {
            PersonaId = personaId;
            NombreUsuario = nombreUsuario;
            Pass = pass;
            FechaCreacion = DateTime.Now;
        }
    }
}