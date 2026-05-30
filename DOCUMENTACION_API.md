# 📋 API Inteligente de Tareas - Documentación

## 🎯 Estado del Proyecto

### ✅ Completado

- [x] Modelo de datos `Tarea` con todas las propiedades
- [x] Enumeraciones: `EstadoTarea` y `PrioridadTarea`
- [x] Contexto de base de datos: `AppDbContext`
- [x] Controlador RESTful: `TareasController`
- [x] Todos los endpoints CRUD implementados
- [x] Validaciones en el modelo
- [x] Página web de prueba interactiva
- [x] Configuración de CORS
- [x] Integración con SQLite

### 📝 Modelo de Datos

```csharp
public class Tarea
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public EstadoTarea Estado { get; set; } = EstadoTarea.Pendiente;
    public PrioridadTarea Prioridad { get; set; } = PrioridadTarea.Media;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaVencimiento { get; set; }
}
```

### 📊 Enumeraciones

**EstadoTarea:**

- `Pendiente` (0)
- `EnProceso` (1)
- `Completada` (2)

**PrioridadTarea:**

- `Baja` (0)
- `Media` (1)
- `Alta` (2)

---

## 🔌 Endpoints RESTful

### 1️⃣ GET /api/tareas

**Obtener todas las tareas**

**URL:**

```
GET https://localhost:7009/api/tareas
```

**Respuesta (200 OK):**

```json
[
  {
    "id": 1,
    "titulo": "Implementar API",
    "descripcion": "Crear endpoints RESTful",
    "estado": "EnProceso",
    "prioridad": "Alta",
    "fechaCreacion": "2026-05-29T10:30:00Z",
    "fechaVencimiento": "2026-06-05T00:00:00Z"
  },
  {
    "id": 2,
    "titulo": "Pruebas unitarias",
    "descripcion": null,
    "estado": "Pendiente",
    "prioridad": "Media",
    "fechaCreacion": "2026-05-29T10:35:00Z",
    "fechaVencimiento": null
  }
]
```

---

### 2️⃣ GET /api/tareas/{id}

**Obtener una tarea específica**

**URL:**

```
GET https://localhost:7009/api/tareas/1
```

**Respuesta (200 OK):**

```json
{
  "id": 1,
  "titulo": "Implementar API",
  "descripcion": "Crear endpoints RESTful",
  "estado": "EnProceso",
  "prioridad": "Alta",
  "fechaCreacion": "2026-05-29T10:30:00Z",
  "fechaVencimiento": "2026-06-05T00:00:00Z"
}
```

**Respuesta (404 Not Found):**

```json
null
```

---

### 3️⃣ POST /api/tareas

**Crear una nueva tarea**

**URL:**

```
POST https://localhost:7009/api/tareas
Content-Type: application/json
```

**Body (ejemplo válido):**

```json
{
  "titulo": "Implementar ML.NET",
  "descripcion": "Integrar modelo de clasificación de sentimientos",
  "estado": "Pendiente",
  "prioridad": "Alta",
  "fechaVencimiento": "2026-06-10T00:00:00Z"
}
```

**Respuesta (201 Created):**

```json
{
  "id": 3,
  "titulo": "Implementar ML.NET",
  "descripcion": "Integrar modelo de clasificación de sentimientos",
  "estado": "Pendiente",
  "prioridad": "Alta",
  "fechaCreacion": "2026-05-29T10:45:00Z",
  "fechaVencimiento": "2026-06-10T00:00:00Z"
}
```

**Validaciones:**

- ❌ Título es obligatorio
- ❌ Estado es obligatorio
- ❌ Prioridad es obligatoria
- ❌ Fecha vencimiento no puede ser menor a hoy

---

### 4️⃣ PUT /api/tareas/{id}

**Actualizar una tarea existente**

**URL:**

```
PUT https://localhost:7009/api/tareas/1
Content-Type: application/json
```

**Body:**

```json
{
  "id": 1,
  "titulo": "Implementar API [ACTUALIZADO]",
  "descripcion": "Crear endpoints RESTful completos",
  "estado": "Completada",
  "prioridad": "Alta",
  "fechaCreacion": "2026-05-29T10:30:00Z",
  "fechaVencimiento": "2026-06-05T00:00:00Z"
}
```

**Respuesta (204 No Content):**

```
(Sin body)
```

**Respuesta (400 Bad Request):**

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Estado": ["El estado es obligatorio."],
    "Prioridad": ["La prioridad es obligatoria."]
  }
}
```

---

### 5️⃣ DELETE /api/tareas/{id}

**Eliminar una tarea**

**URL:**

```
DELETE https://localhost:7009/api/tareas/1
```

**Respuesta (204 No Content):**

```
(Sin body)
```

**Respuesta (404 Not Found):**

```
(No content)
```

---

## 🧪 Pruebas de la API

### Opción 1: Página Web Interactiva

**URL:** `https://localhost:7009/`

Características:

- ✅ Interfaz moderna y responsiva
- ✅ Formulario para crear tareas
- ✅ Tabla de tareas con búsqueda
- ✅ Modal para editar tareas
- ✅ Botones para eliminar
- ✅ Validaciones en tiempo real
- ✅ Estadísticas en vivo
- ✅ Manejo de errores

### Opción 2: Prueba con curl

```bash
# GET todas las tareas
curl -X GET "https://localhost:7009/api/tareas" --insecure

# GET una tarea específica
curl -X GET "https://localhost:7009/api/tareas/1" --insecure

# POST crear tarea
curl -X POST "https://localhost:7009/api/tareas" \
  -H "Content-Type: application/json" \
  --insecure \
  -d '{
    "titulo": "Mi tarea",
    "descripcion": "Descripción opcional",
    "estado": "Pendiente",
    "prioridad": "Media",
    "fechaVencimiento": "2026-06-15T00:00:00Z"
  }'

# PUT actualizar tarea
curl -X PUT "https://localhost:7009/api/tareas/1" \
  -H "Content-Type: application/json" \
  --insecure \
  -d '{
    "id": 1,
    "titulo": "Tarea actualizada",
    "descripcion": "Nueva descripción",
    "estado": "EnProceso",
    "prioridad": "Alta",
    "fechaCreacion": "2026-05-29T10:30:00Z",
    "fechaVencimiento": "2026-06-10T00:00:00Z"
  }'

# DELETE eliminar tarea
curl -X DELETE "https://localhost:7009/api/tareas/1" --insecure
```

### Opción 3: Postman

1. Crear nueva colección "API Tareas"
2. Importar las siguientes requests:

**GET /api/tareas**

```
Method: GET
URL: https://localhost:7009/api/tareas
```

**GET /api/tareas/{id}**

```
Method: GET
URL: https://localhost:7009/api/tareas/{{id}}
```

**POST /api/tareas**

```
Method: POST
URL: https://localhost:7009/api/tareas
Body (JSON):
{
  "titulo": "Nueva tarea",
  "descripcion": "Descripción",
  "estado": "Pendiente",
  "prioridad": "Media",
  "fechaVencimiento": "2026-06-15"
}
```

**PUT /api/tareas/{id}**

```
Method: PUT
URL: https://localhost:7009/api/tareas/{{id}}
Body (JSON):
{
  "id": {{id}},
  "titulo": "Tarea actualizada",
  "descripcion": "Nueva descripción",
  "estado": "EnProceso",
  "prioridad": "Alta",
  "fechaCreacion": "2026-05-29T10:30:00Z",
  "fechaVencimiento": "2026-06-15T00:00:00Z"
}
```

**DELETE /api/tareas/{id}**

```
Method: DELETE
URL: https://localhost:7009/api/tareas/{{id}}
```

---

## ✅ Validaciones Implementadas

| Campo                 | Validación | Mensaje                                                         |
| --------------------- | ---------- | --------------------------------------------------------------- |
| **Título**            | Requerido  | "El título es obligatorio."                                     |
| **Estado**            | Requerido  | "El estado es obligatorio."                                     |
| **Prioridad**         | Requerida  | "La prioridad es obligatoria."                                  |
| **Fecha Vencimiento** | >= Hoy     | "La fecha de vencimiento no puede ser menor a la fecha actual." |

---

## 🗄️ Base de Datos

**Motor:** SQLite
**Archivo:** `tareas.db` (generado automáticamente)

**Tabla: Tareas**

```sql
CREATE TABLE Tareas (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Titulo TEXT NOT NULL,
    Descripcion TEXT,
    Estado TEXT NOT NULL,
    Prioridad TEXT NOT NULL,
    FechaCreacion TEXT NOT NULL,
    FechaVencimiento TEXT
);
```

---

## 🚀 Próximas Fases (No implementadas aún)

1. **Consumo de API Externa**
   - Integración con una API pública (ej: OpenWeather, JSONPlaceholder)
   - Enriquecimiento de tareas con datos externos

2. **Integración ML.NET**
   - Modelo de clasificación de sentimientos para comentarios
   - Recomendador de tareas por categoría

3. **Versionamiento y Pull Requests**
   - Una rama por cada funcionalidad
   - PR hacia main

---

## 📋 Checklist de Validación

- [x] Modelo Tarea con todas las propiedades
- [x] Estados: Pendiente, EnProceso, Completada
- [x] Prioridades: Baja, Media, Alta
- [x] GET /api/tareas
- [x] GET /api/tareas/{id}
- [x] POST /api/tareas
- [x] PUT /api/tareas/{id}
- [x] DELETE /api/tareas/{id}
- [x] Validación: Título obligatorio
- [x] Validación: Estado obligatorio
- [x] Validación: Prioridad obligatoria
- [x] Validación: Fecha vencimiento >= hoy
- [x] Página web de prueba
- [x] Manejo de errores
- [x] Base de datos SQLite
