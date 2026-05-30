using ApiTareas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiTareas.Controllers
{
    [ApiController]
    [Route("api/tareas-externas")]
    public class TareasExternasController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TareasExternasController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetTareasExternas()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("JsonPlaceholder");
                var response = await client.GetAsync("todos");

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode(502, new { message = "Error al comunicarse con la API externa." });
                }

                var jsonStr = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var todos = JsonSerializer.Deserialize<List<JsonPlaceholderTodo>>(jsonStr, options);

                if (todos == null)
                {
                    return StatusCode(502, new { message = "Error al procesar la respuesta de la API externa." });
                }

                var dtos = todos.Select(t => new TareaExternaDto
                {
                    ExternalId = t.Id,
                    Titulo = t.Title,
                    Completado = t.Completed
                }).ToList();

                return Ok(dtos);
            }
            catch (Exception)
            {
                return StatusCode(502, new { message = "Error al comunicarse con la API externa." });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTareaExterna(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("JsonPlaceholder");
                var response = await client.GetAsync($"todos/{id}");

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound(new { message = $"No se encontró la tarea externa con ID {id}." });
                }

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode(502, new { message = "Error al comunicarse con la API externa." });
                }

                var jsonStr = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var todo = JsonSerializer.Deserialize<JsonPlaceholderTodo>(jsonStr, options);

                if (todo == null)
                {
                    return StatusCode(502, new { message = "Error al procesar la respuesta de la API externa." });
                }

                var dto = new TareaExternaDto
                {
                    ExternalId = todo.Id,
                    Titulo = todo.Title,
                    Completado = todo.Completed
                };

                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(502, new { message = "Error al comunicarse con la API externa." });
            }
        }
    }
}
