# API Inteligente de Tareas y Análisis

## Project Overview

This is a .NET 10.0 Web API project serving as a Smart Task Management and Analysis API (API Inteligente de Tareas y Análisis). 

**Key Technologies:**
- **Framework:** .NET 10.0 (ASP.NET Core Web API)
- **Database:** SQLite (`tareas.db`)
- **ORM:** Entity Framework Core (EF Core)
- **Documentation:** OpenAPI (natively mapped via `MapOpenApi` in .NET 10)
- **Frontend:** A built-in interactive HTML/JS client hosted via Static Files at the root (`/wwwroot/index.html`).

**Architecture & Features:**
- A RESTful architecture centered around a `Tarea` (Task) model.
- Complete CRUD operations exposed via `TareasController` at `/api/tareas`.
- Enums (`EstadoTarea`, `PrioridadTarea`) are serialized as strings for better readability.
- Basic built-in validations (e.g., Required fields, Due Date >= Today).
- CORS is configured to "AllowAll" for development.

**Upcoming Phases (Roadmap):**
- Integration with an external API (e.g., OpenWeather, JSONPlaceholder).
- ML.NET integration for sentiment analysis and task recommendations.
- Version control and Pull Request workflow adoption.

## Building and Running

### Prerequisites
- .NET 10.0 SDK

### Commands
- **Restore Dependencies:**
  ```bash
  dotnet restore
  ```
- **Build the Project:**
  ```bash
  dotnet build
  ```
- **Run the Application:**
  ```bash
  dotnet run
  ```
  The API and the interactive web interface will typically be accessible at `https://localhost:7009/` (verify exact port in your console output or `Properties/launchSettings.json`).

- **Database Migrations (Entity Framework Core):**
  To add a new migration after modifying models:
  ```bash
  dotnet ef migrations add <MigrationName>
  ```
  To apply migrations to the database:
  ```bash
  dotnet ef database update
  ```

## Development Conventions

- **Language:** The codebase models, properties, comments, and documentation are predominantly in **Spanish**. Maintain this language convention for new models, properties, API responses, and validation messages.
- **API Responses:** 
  - `200 OK` for successful GET.
  - `201 Created` for successful POST.
  - `204 No Content` for successful PUT/DELETE.
  - `400 Bad Request` for validation failures.
  - `404 Not Found` for missing resources.
- **Serialization:** Enums are strictly serialized as Strings in JSON responses, configured via `JsonStringEnumConverter` in `Program.cs`.
- **Validation:** Validation rules are enforced in models resulting in standard RFC 7231 Problem Details responses on `400 Bad Request`. Ensure new validations return localized Spanish messages (e.g., "El título es obligatorio.").
