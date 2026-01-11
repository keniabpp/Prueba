using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaProject.Domain.Entities
{
    [Table("Personas")]
    public class Persona
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string NumeroIdentificacion { get; set; } = string.Empty;
        public string TipoIdentificacion { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime FechaCreacion  { get; set; } = DateTime.Now;

        // Columnas calculadas - solo lectura
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string? IdentificacionCompleta { get; private set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string? NombreCompleto { get; private set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; }


        //Constructor vacio
        public Persona()
        {
            
        }

        //Constructor con parametros
        public Persona(string nombres, string apellidos, string numeroIdentificacion, string tipoIdentificacion, string email, DateTime fechaCreacion)
        {
            Nombres = nombres;
            Apellidos = apellidos;
            NumeroIdentificacion = numeroIdentificacion;
            TipoIdentificacion = tipoIdentificacion;
            Email = email;
            FechaCreacion = DateTime.Now;
        }
    }


}