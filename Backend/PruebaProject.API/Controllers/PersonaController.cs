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



    }
}