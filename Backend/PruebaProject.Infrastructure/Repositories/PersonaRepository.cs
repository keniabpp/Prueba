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
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AppDbContext _context;

        public  PersonaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async  Task<Persona> CrearAsync(Persona persona)
        {
            _context.Personas.Add(persona);
            await  _context.SaveChangesAsync();
            return persona;
        }

        public async Task<Persona?> ObtenerPorIdAsync(int id)
        {
            return await _context.Personas
            .Include(p => p.Usuario).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Persona>> ObtenerTodosAsync()
        {
          var personas = await _context.Personas.FromSqlRaw("EXEC sp_ConsultarPersonas")
         .AsNoTracking()          
         .ToListAsync();

         return personas;
        }



        
    }
}