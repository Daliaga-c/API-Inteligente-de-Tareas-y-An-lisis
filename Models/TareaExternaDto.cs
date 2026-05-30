using System.Text.Json.Serialization;

namespace ApiTareas.Models
{
    public class TareaExternaDto
    {
        [JsonPropertyName("externalId")]
        public int ExternalId { get; set; }
        
        [JsonPropertyName("titulo")]
        public string Titulo { get; set; } = string.Empty;
        
        [JsonPropertyName("completado")]
        public bool Completado { get; set; }
    }

    public class JsonPlaceholderTodo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
    }
}