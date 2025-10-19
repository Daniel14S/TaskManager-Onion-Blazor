# 📋 Task Manager - Arquitectura Onion con Blazor

Sistema de gestión de tareas desarrollado con **Arquitectura Onion**, **Blazor Server** y **.NET 8**.

## 🏗️ Arquitectura

Este proyecto implementa la **Arquitectura Onion** (Cebolla) que consta de las siguientes capas:

```
┌─────────────────────────────────────┐
│         Presentación (Web)          │  ← Blazor Server UI
├─────────────────────────────────────┤
│       Infraestructura               │  ← EF Core, Repositorios
├─────────────────────────────────────┤
│         Aplicación                  │  ← Servicios, Interfaces
├─────────────────────────────────────┤
│      Dominio (Core)                 │  ← Entidades, Lógica de negocio
└─────────────────────────────────────┘
```

### Capas del Proyecto

- **TaskManager.Domain**: Entidades del dominio (núcleo de la aplicación)
- **TaskManager.Application**: Lógica de negocio e interfaces
- **TaskManager.Infrastructure**: Implementación de acceso a datos (EF Core)
- **TaskManager.Web**: Interfaz de usuario con Blazor Server

## 🚀 Tecnologías Utilizadas

- **.NET 8**
- **Blazor Server**
- **Entity Framework Core**
- **SQLite**
- **Bootstrap 5**

## 📋 Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022, VS Code o JetBrains Rider
- Git

## 🔧 Instalación y Ejecución

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/TaskManager-Onion-Blazor.git
cd TaskManager-Onion-Blazor
```

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Compilar el proyecto

```bash
dotnet build
```

### 4. Ejecutar la aplicación

```bash
dotnet run --project src/TaskManager.Web/TaskManager.Web.csproj
```

### 5. Abrir en el navegador

Navega a: `https://localhost:5001` o `http://localhost:5000`

## 📁 Estructura del Proyecto

```
TaskManager-Onion-Blazor/
├── src/
│   ├── TaskManager.Domain/
│   │   └── Entities/
│   │       └── TaskItem.cs
│   ├── TaskManager.Application/
│   │   ├── Interfaces/
│   │   │   ├── ITaskRepository.cs
│   │   │   └── ITaskService.cs
│   │   └── Services/
│   │       └── TaskService.cs
│   ├── TaskManager.Infrastructure/
│   │   ├── Data/
│   │   │   └── AppDbContext.cs
│   │   └── Repositories/
│   │       └── TaskRepository.cs
│   └── TaskManager.Web/
│       ├── Pages/
│       │   ├── Tasks.razor
│       │   └── Index.razor
│       ├── Shared/
│       │   └── NavMenu.razor
│       ├── Program.cs
│       └── appsettings.json
├── .gitignore
├── README.md
└── TaskManager.sln
```

## ✨ Características

- ✅ Crear nuevas tareas con título, descripción y prioridad
- ✅ Listar tareas pendientes y completadas
- ✅ Marcar tareas como completadas
- ✅ Eliminar tareas
- ✅ Sistema de prioridades (Baja, Media, Alta, Crítica)
- ✅ Interfaz responsiva con Bootstrap
- ✅ Base de datos SQLite local

## 🎯 Principios de Arquitectura Onion

1. **Independencia del Framework**: El dominio no depende de frameworks externos
2. **Testeable**: Cada capa puede ser testeada independientemente
3. **Independencia de la UI**: La UI puede cambiar sin afectar la lógica de negocio
4. **Independencia de la Base de Datos**: Fácil cambiar de SQLite a otro motor
5. **Regla de Dependencia**: Las dependencias apuntan hacia el centro (Dominio)

## 🔄 Flujo de Datos

```
Usuario → Blazor Component → ITaskService → ITaskRepository → DbContext → SQLite
```

## 📝 Comandos Útiles

### Compilar
```bash
dotnet build
```

### Ejecutar
```bash
dotnet run --project src/TaskManager.Web/TaskManager.Web.csproj
```

### Limpiar build
```bash
dotnet clean
```

### Agregar migración (si usas Migrations)
```bash
dotnet ef migrations add InitialCreate --project src/TaskManager.Infrastructure --startup-project src/TaskManager.Web
```

## 🤝 Contribuir

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/NuevaCaracteristica`)
3. Commit tus cambios (`git commit -m 'Agregar nueva característica'`)
4. Push a la rama (`git push origin feature/NuevaCaracteristica`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto es de código abierto y está disponible bajo la licencia MIT.

## 👨‍💻 Autor

Tu Nombre - [@tu-usuario](https://github.com/tu-usuario)

## 🙏 Agradecimientos

- Arquitectura Onion por Jeffrey Palermo
- Microsoft por .NET y Blazor
- Comunidad de desarrolladores .NET
