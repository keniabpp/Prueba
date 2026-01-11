# PruebaProject - Frontend Angular

Sistema de Gestión de Personas desarrollado con Angular 18 y Bootstrap.

## 🚀 Tecnologías Utilizadas

- **Angular 18**
- **TypeScript**
- **Bootstrap 5** (UI/Styling)
- **Bootstrap Icons**
- **Standalone Components**
- **FormsModule** (Template-driven forms)
- **Nueva sintaxis de control de flujo**: `@if`, `@for`

## ✨ Funcionalidades

- 🔐 **Autenticación** (Login/Logout)
- 📝 **Registro de personas** con validaciones
- 👥 **Creación de usuarios** con contraseñas seguras
- 📊 **Dashboard** con lista de personas
- 👁️ **Mostrar/ocultar contraseña**
- ✅ **Validaciones** en frontend y backend
- 📱 **Responsive design**

## 🔧 Instalación y Ejecución

### Pre-requisitos

- Node.js 18+
- npm
- Angular CLI: `npm install -g @angular/cli`

### 1. Navegar al directorio del frontend

```bash
cd frontend
cd prueba ng serve
```

### 2. Instalar dependencias

```bash
npm install
```

### 3. Ejecutar servidor de desarrollo

```bash
ng serve
```

La aplicación estará disponible en `http://localhost:4200/`

### 4. Asegúrate de que el Backend esté ejecutándose

El frontend se conecta automáticamente al backend en `http://localhost:5218`

## 📱 Rutas de la Aplicación

- `/` - Página principal
- `/login` - Iniciar sesión
- `/register` - Registro de personas y usuarios
- `/dashboard` - Panel principal (requiere autenticación)

## 🏗️ Estructura del Proyecto

```
src/
├── app/
│   ├── components/
│   │   ├── auth/
│   │   │   ├── login/
│   │   │   └── register/
│   │   └── dashboard/
│   ├── services/
│   │   └── persona.service.ts
│   ├── Models/
│   │   ├── persona.model.ts
│   │   └── usuario.model.ts
│   └── environments/
└── assets/
```

## 🛠️ Comandos Disponibles

### Desarrollo
```bash
ng serve               # Servidor de desarrollo
ng build              # Build de producción
ng build --watch      # Build con watch mode
```

### Testing
```bash
ng test               # Unit tests con Karma
ng e2e               # End-to-end tests
```

### Generación de código
```bash
ng generate component nombre    # Generar componente
ng generate service nombre      # Generar servicio
ng generate --help             # Ver todas las opciones
```

## 🔗 API Endpoints Utilizados

- `GET /api/persona` - Obtener personas
- `POST /api/persona/crear` - Crear persona
- `POST /api/persona/crear-usuario` - Crear usuario
- `POST /api/persona/login` - Login

## 🎨 Estilos y UI

- **Bootstrap 5** para diseño responsive
- **Bootstrap Icons** para iconografía
- **CSS personalizado** para estilos específicos

## 🧑‍💻 Desarrollado por

**Kenia Beatriz Palomeque Pino**  
📧 keniabpp@outlook.com

---

> Este proyecto fue generado con [Angular CLI](https://github.com/angular/angular-cli) version 18.x
