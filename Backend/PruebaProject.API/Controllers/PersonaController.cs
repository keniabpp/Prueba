using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaProject.Application.Interfaces;
using PruebaProject.Domain.Entities;
using PruebaProject.Infrastructure.Services;

namespace PruebaProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> CrearPersona([FromBody] Persona persona)
        {
            if (persona == null)
            {
                return BadRequest("Datos invalidos");
            }
            
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(persona.Nombres))
            {
                return BadRequest("El campo Nombres es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(persona.Apellidos))
            {
                return BadRequest("El campo Apellidos es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(persona.NumeroIdentificacion))
            {
                return BadRequest("El campo Numero de Identificación es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(persona.TipoIdentificacion))
            {
                return BadRequest("El campo Tipo de Identificación es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(persona.Email))
            {
                return BadRequest("El campo Email es obligatorio");
            }
            
            var personaCreada = await _personaService.CrearPersonaAsync(persona);
            return Ok(personaCreada);
        }

        [HttpPost("crear-usuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Datos invalidos");
            }
            
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
            {
                return BadRequest("El campo Nombre de Usuario es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(usuario.Pass))
            {
                return BadRequest("El campo Contraseña es obligatorio");
            }
            
            // Validar longitud mínima de contraseña
            if (usuario.Pass.Length < 8)
            {
                return BadRequest("La contraseña debe tener al menos 8 caracteres");
            }
            
            // Validar contraseña con caracteres especiales
            if (!ContienCaracterEspecial(usuario.Pass))
            {
                return BadRequest("La contraseña debe contener al menos un carácter especial (!@#$%^&*()_+-=[]{}|;:,.<>?)");
            }
            
            if (usuario.PersonaId <= 0)
            {
                return BadRequest("El PersonaId es obligatorio y debe ser válido");
            }
            
            var usuarioCreado = await _personaService.CrearUsuarioAsync(usuario);
            return Ok(usuarioCreado);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario login)
        {
            if (login == null)
            {
                return BadRequest("usuario o contraseña invalidos");
            }
            var usuario = await _personaService.ValidarLoginAsync(login.NombreUsuario, login.Pass.ToString());
            if (usuario == null)
            {
                return Unauthorized("Credenciales invalidas");
            }
            return Ok(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasPersonas()
        {
            var personas = await _personaService.ObtenerTodasPersonasAsync();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPersonaPorId(int id)
        {
            var persona = await _personaService.ObtenerPersonaPorIdAsync(id);
            if (persona == null)
            {
                return NotFound($"Persona con ID {id} no encontrada");
            }
            return Ok(persona);
        }

        // Método para validar caracteres especiales en contraseña
        private bool ContienCaracterEspecial(string password)
        {
            string caracteresEspeciales = "!@#$%^&*()_+-=[]{}|;:,.<>?";
            return password.Any(c => caracteresEspeciales.Contains(c));
        }


    }
}