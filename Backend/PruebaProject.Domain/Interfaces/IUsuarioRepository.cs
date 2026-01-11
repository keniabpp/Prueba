using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaProject.Domain.Entities;

namespace PruebaProject.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> CrearAsync(Usuario usuario);
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task<Usuario?> ObtenerPorNombreAsync(string nombreUsuario);
    }
}