# PruebaProject - Arquitectura Onion en C#

Este proyecto implementa una aplicación web API utilizando **Arquitectura Onion (Clean Architecture)** con .NET 10 y Entity Framework Core.

## 🏗️ Arquitectura del Proyecto

### Capas del Proyecto

1. **PruebaProject.Domain** (Núcleo)
   - Entidades del dominio
   - Value Objects
   - Interfaces del dominio
   - Lógica de negocio pura

2. **PruebaProject.Application** (Casos de Uso)
   - Servicios de aplicación
   - DTOs (Data Transfer Objects)
   - Commands y Queries (CQRS)
   - Interfaces de servicios

3. **PruebaProject.Infrastructure** (Implementación)
   - Repositorios
   - Entity Framework DbContext
   - Configuración de base de datos

4. **PruebaProject.API** (Presentación)
   - Controladores Web API
   - Configuración de dependencias
   - Swagger/OpenAPI

## 🚀 Tecnologías Utilizadas

- **.NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core 10**
- **SQL Server**
- **(Swagger)**
- **Dependency Injection**

## 📁 Estructura del Proyecto

```
PruebaProject/
├── PruebaProject.Domain/
│   ├── Entities/
│   │   ├── BaseEntity.cs
│   │   └── User.cs
│   ├── ValueObjects/
│   │   └── Email.cs
│   └── Interfaces/
│       ├── IUserRepository.cs
│       
├── PruebaProject.Application/
│   ├── Commands/
│   │   ├── CreateUserCommand.cs
│   │   └── UpdateUserCommand.cs
│   ├── Queries/
│   │   └── UserQueries.cs
│   ├── DTOs/
│   │   └── UserDto.cs
│   ├── Services/
│   │   └── UserService.cs
│   ├── Interfaces/
│   │   └── IUserService.cs
│   └── DependencyInjection.cs
├── PruebaProject.Infrastructure/
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Repositories/
│   │   └── UserRepository.cs
│   ├── UnitOfWork/
│   │   └── UnitOfWork.cs
│   └── DependencyInjection.cs
└── PruebaProject.API/
    ├── Controllers/
    │   └── UsersController.cs
    ├── appsettings.json
    └── Program.cs
```

## 🔧 Configuración y Ejecución

### Pre-requisitos

- .NET 10 SDK
- SQL Server o SQL Server LocalDB
- Visual Studio Code o Visual Studio

### 1. Clonar e instalar dependencias

```bash
git clone [repositorio]
cd PruebaProject
dotnet restore
```

### 2. Configurar Base de Datos

Actualizar la cadena de conexión en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PruebaProjectDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 3. Crear Migraciones (Opcional)

```bash
# Crear primera migración
dotnet ef migrations add InitialCreate --project PruebaProject.Infrastructure --startup-project PruebaProject.API

# Actualizar base de datos
dotnet ef database update --project PruebaProject.Infrastructure --startup-project PruebaProject.API
```

### 4. Ejecutar la aplicación

```bash
dotnet run --project PruebaProject.API
```

La aplicación estará disponible en:
- **HTTPS**: https://localhost:7123
- **HTTP**: http://localhost:5123
- **Swagger UI**: https://localhost:7123/swagger

## 📚 API Endpoints

### Usuarios

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET    | `/api/users` | Obtener todos los usuarios |
| GET    | `/api/users/{id}` | Obtener usuario por ID |
| POST   | `/api/users` | Crear nuevo usuario |
| PUT    | `/api/users/{id}` | Actualizar usuario |
| DELETE | `/api/users/{id}` | Eliminar usuario |

### Ejemplo de uso con curl:

```bash
# Crear usuario
curl -X POST https://localhost:7123/api/users \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Juan",
    "lastName": "Pérez",
    "email": "juan.perez@email.com"
  }'

# Obtener todos los usuarios
curl https://localhost:7123/api/users
```

## 🎯 Patrones Implementados

### 1. **Arquitectura Onion**
- Separación clara de responsabilidades
- Dependencias apuntan hacia adentro
- Domain es independiente de infraestructura

### 2. **Repository Pattern**
- Abstracción de acceso a datos
- Facilita testing y cambio de proveedores

### 3. **Unit of Work**
- Gestión de transacciones
- Control consistente de cambios

### 4. **Value Objects**
- Email como value object inmutable
- Validación encapsulada

### 5. **CQRS Básico**
- Separación de Commands y Queries
- Claridad en operaciones

## 🧪 Testing

Para ejecutar tests (cuando se implementen):

```bash
dotnet test
```

## 📝 Notas de Desarrollo

### Agregar nueva entidad:

1. Crear entidad en `Domain/Entities`
2. Agregar repositorio en `Domain/Interfaces`
3. Implementar repositorio en `Infrastructure/Repositories`
4. Agregar al Unit of Work
5. Crear DTOs en `Application/DTOs`
6. Crear servicio en `Application/Services`
7. Crear controlador en `API/Controllers`

### Migración de base de datos:

```bash
# Agregar migración
dotnet ef migrations add [NombreMigracion] --project PruebaProject.Infrastructure --startup-project PruebaProject.API

# Aplicar migración
dotnet ef database update --project PruebaProject.Infrastructure --startup-project PruebaProject.API
```

## 🤝 Contribución

1. Fork del proyecto
2. Crear rama feature (`git checkout -b feature/AmazingFeature`)
3. Commit cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE.md](LICENSE.md) para detalles.

## 👥 Autor

- **Desarrollador** - *Trabajo inicial* - [TuNombre](https://github.com/tunombre)