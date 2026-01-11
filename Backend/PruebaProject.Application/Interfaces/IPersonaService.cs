using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaProject.Domain.Entities;

namespace PruebaProject.Application.Interfaces
{
    public interface IPersonaService
    {
        Task<Persona> CrearPersonaAsync(Persona persona);
        Task<Usuario> CrearUsuarioAsync(Usuario usuario);
        Task<IEnumerable<Persona>> ObtenerTodasPersonasAsync();
        Task<Persona?> ObtenerPersonaPorIdAsync(int id);
        Task<Usuario?> ValidarLoginAsync(string nombreUsuario, string pass);
       
    }
}