using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaProject.Domain.Entities;
using PruebaProject.Domain.Interfaces;
using PruebaProject.Infrastructure.Data;

namespace PruebaProject.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CrearAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios
            .Include(u => u.Persona).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario?> ObtenerPorNombreAsync(string nombreUsuario)
        {
            return await _context.Usuarios
            .Include(u => u.Persona)
            .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }
    }
}