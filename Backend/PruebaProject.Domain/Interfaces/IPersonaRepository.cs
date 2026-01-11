using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaProject.Domain.Entities;

namespace PruebaProject.Domain.Interfaces
{
    public interface IPersonaRepository
    {
        Task<Persona> CrearAsync(Persona persona);
        Task<Persona?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Persona>> ObtenerTodosAsync();

    }
}