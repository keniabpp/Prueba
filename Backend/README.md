# PruebaProject - Sistema de Gestión de Personas

Este proyecto implementa un sistema completo de gestión de personas con autenticación segura, utilizando **Arquitectura Onion (Clean Architecture)** con .NET 10, Entity Framework Core y frontend en Angular 18.

## 🏗️ Arquitectura del Proyecto

### Backend - Arquitectura Onion

1. **PruebaProject.Domain** (Núcleo)
   - Entidades: `Persona`, `Usuario`
   - Interfaces del dominio: `IPersonaRepository`, `IUsuarioRepository`

2. **PruebaProject.Application** (Casos de Uso)
   - Interfaces de servicios: `IPersonaService`
   - Inyección de dependencias

3. **PruebaProject.Infrastructure** (Implementación)
   - Repositorios: `PersonaRepository`, `UsuarioRepository`
   - Entity Framework DbContext: `AppDbContext`
   - Servicios: `PersonaService` con BCrypt para seguridad
   - Configuración de base de datos

4. **PruebaProject.API** (Presentación)
   - Controladores Web API: `PersonaController`
   - Configuración de dependencias y CORS
   - Swagger/OpenAPI

#
## 🚀 Tecnologías Utilizadas

### Backend
- **.NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core 10.0.1**
- **SQL Server**
- **BCrypt.Net-Next 4.0.3** (Seguridad de contraseñas)
- **Swagger/OpenAPI**
- **Dependency Injection**

## 🔧 Configuración y Ejecución

### Pre-requisitos

- .NET 10 SDK
- Node.js 18+ y npm
- SQL Server o SQL Server LocalDB
- Angular CLI: `npm install -g @angular/cli`
- Visual Studio Code (recomendado)

### 1. Configurar Base de Datos

Actualizar la cadena de conexión en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Prueba;Integrated Security=true;TrustServerCertificate=true"
  }
}
```

### 2. Ejecutar Backend

```bash
cd Backend
dotnet restore
dotnet build
cd PruebaProject.API
dotnet run
```

El backend estará disponible en: `http://localhost:5218`

### 3. Ejecutar Frontend

```bash
cd Frontend/prueba
npm install
ng serve
```

El frontend estará disponible en: `http://localhost:4200`

## 📊 Base de Datos

### Tablas Principales

**Personas**
- Id (Primary Key)
- Nombres
- Apellidos
- NumeroIdentificacion
- TipoIdentificacion
- Email
- FechaCreacion

**Usuarios**
- Id (Primary Key)
- PersonaId (Foreign Key)
- NombreUsuario
- Pass (Hasheada con BCrypt)
- FechaCreacion

## 🔗 Endpoints de la API

### Personas
- `GET /api/persona` - Obtener todas las personas
- `GET /api/persona/{id}` - Obtener persona por ID
- `POST /api/persona/crear` - Crear nueva persona

### Usuarios
- `POST /api/persona/crear-usuario` - Crear nuevo usuario
- `POST /api/persona/login` - Autenticación de usuario


## 🔐 Seguridad Implementada

1. **Contraseñas hasheadas** con BCrypt (salt rounds por defecto)
2. **Validación de contraseñas fuertes**: mínimo 8 caracteres + carácter especial
3. **Validación backend** para prevenir datos maliciosos
4. **CORS configurado** específicamente para Angular
5. **Validación de campos obligatorios** en ambos lados


## 🧑‍💻 Desarrollado por

**Kenia Beatriz Palomeque Pino**  
📧 keniabpp@outlook.com

Sistema desarrollado como proyecto de demostración de arquitectura clean y mejores prácticas de seguridad.

## 🌐 URLs de la Aplicación

Después de ejecutar ambos servicios:

### Backend API
- **HTTP**: http://localhost:5218
- **Swagger UI**: http://localhost:5218/swagger

### Frontend Angular
- **HTTP**: http://localhost:4200

## 📝 Notas Importantes

- Asegúrate de que SQL Server esté funcionando antes de ejecutar el backend
- El frontend se conecta automáticamente al backend en el puerto 5218
- Las contraseñas se hashean automáticamente con BCrypt para seguridad


## 📄 Licencia

Este proyecto está bajo la Licencia MIT.