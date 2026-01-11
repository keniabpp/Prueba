using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaProject.Application.Interfaces;
using PruebaProject.Domain.Entities;
using PruebaProject.Domain.Interfaces;

namespace PruebaProject.Infrastructure.Services
{
    public class PersonaServices : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public PersonaServices(IPersonaRepository personaRepository, IUsuarioRepository usuarioRepository)
        {
            _personaRepository = personaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Persona> CrearPersonaAsync(Persona persona)
        {
            return await _personaRepository.CrearAsync(persona);
        }

        public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            return await _usuarioRepository.CrearAsync(usuario);
        }

        public async Task<Persona?> ObtenerPersonaPorIdAsync(int id)
        {
            return await _personaRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Persona>> ObtenerTodasPersonasAsync()
        {
            return await _personaRepository.ObtenerTodosAsync();
        }

        public async Task<Usuario?> ValidarLoginAsync(string nombreUsuario, string pass)
        {
            var usuario = await _usuarioRepository.ObtenerPorNombreAsync(nombreUsuario);
            if (usuario != null && usuario.Pass.ToString() == pass)
            {
                return usuario;
            }
            return null;
        }
    }
}