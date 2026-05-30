using System;
using System.ComponentModel.DataAnnotations;

namespace ApiTareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public EstadoTarea Estado { get; set; } = EstadoTarea.Pendiente;

        [Required(ErrorMessage = "La prioridad es obligatoria.")]
        public PrioridadTarea Prioridad { get; set; } = PrioridadTarea.Media;

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        [FechaVencimientoValida(ErrorMessage = "La fecha de vencimiento no puede ser menor a la fecha actual.")]
        public DateTime? FechaVencimiento { get; set; }
    }

    public class FechaVencimientoValidaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime fechaVencimiento)
            {
                if (fechaVencimiento.Date < DateTime.UtcNow.Date)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}