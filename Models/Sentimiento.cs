using Microsoft.ML.Data;

namespace ApiTareas.Models;

public class SentimientoRequest
{
    public string Comentario { get; set; } = string.Empty;
}

public class SentimientoResponse
{
    public string Comentario { get; set; } = string.Empty;
    public string Sentimiento { get; set; } = string.Empty;
}

public class SentimientoData
{
    [LoadColumn(0)]
    public string Texto { get; set; } = string.Empty;

    [LoadColumn(1), ColumnName("Label")]
    public bool Sentimiento { get; set; } // true = Positivo, false = Negativo
}

public class SentimientoPrediction : SentimientoData
{
    [ColumnName("PredictedLabel")]
    public bool Prediccion { get; set; }

    public float Probability { get; set; }
    public float Score { get; set; }
}