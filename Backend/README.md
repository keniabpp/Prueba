# PruebaProject - Arquitectura Onion en C#

Este proyecto implementa una aplicación web API utilizando **Arquitectura Onion (Clean Architecture)** con .NET 10 y Entity Framework Core.

## 🏗️ Arquitectura del Proyecto

### Capas del Proyecto

1. **PruebaProject.Domain** (Núcleo)
   - Entidades del dominio
   - Value Objects
   - Interfaces del dominio
   

2. **PruebaProject.Application** (Casos de Uso)
   - Servicios de aplicación
   - DTOs (Data Transfer Objects)
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





### 3. Ejecutar la aplicación

```bash
dotnet run --project PruebaProject.API
```

La aplicación estará disponible en:
- **HTTPS**: https://localhost:7123
- **HTTP**: http://localhost:5123
- **Swagger UI**: https://localhost:7123/swagger

## 📚 API Endpoints

### Usuarios


## 🧪 Testing

Para ejecutar tests (cuando se implementen):

```bash
dotnet test

``
Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE.md](LICENSE.md) para detalles.

## 👥 Autor

- **Desarrollador** - *Trabajo inicial* - [TuNombre](https://github.com/tunombre)