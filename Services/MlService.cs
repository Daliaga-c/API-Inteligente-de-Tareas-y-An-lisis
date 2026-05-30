using ApiTareas.Models;
using Microsoft.ML;

namespace ApiTareas.Services;

public class MlService
{
    private readonly MLContext _mlContext;
    private readonly PredictionEngine<SentimientoData, SentimientoPrediction> _predictionEngine;

    public MlService()
    {
        _mlContext = new MLContext();

        // Pequeño dataset en memoria
        var trainingData = new[]
        {
            new SentimientoData { Texto = "La tarea fue completada correctamente y el sistema funciona bien", Sentimiento = true },
            new SentimientoData { Texto = "Excelente trabajo, todo perfecto", Sentimiento = true },
            new SentimientoData { Texto = "Me encantó el resultado final", Sentimiento = true },
            new SentimientoData { Texto = "Muy buen desempeño en el proyecto", Sentimiento = true },
            new SentimientoData { Texto = "Todo mal, nada funciona", Sentimiento = false },
            new SentimientoData { Texto = "Pésimo servicio, muy decepcionado", Sentimiento = false },
            new SentimientoData { Texto = "El sistema se bloquea constantemente", Sentimiento = false },
            new SentimientoData { Texto = "No me gusta para nada", Sentimiento = false },
            new SentimientoData { Texto = "Hubo muchos errores durante la ejecución", Sentimiento = false },
            new SentimientoData { Texto = "Buen trabajo, aunque con retrasos", Sentimiento = true },
            new SentimientoData { Texto = "Es un desastre total", Sentimiento = false }
        };

        var dataView = _mlContext.Data.LoadFromEnumerable(trainingData);

        // Pipeline de entrenamiento
        var pipeline = _mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimientoData.Texto))
            .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

        // Entrenar el modelo
        var model = pipeline.Fit(dataView);

        // Crear el motor de predicción
        _predictionEngine = _mlContext.Model.CreatePredictionEngine<SentimientoData, SentimientoPrediction>(model);
    }

    public string PredecirSentimiento(string texto)
    {
        var input = new SentimientoData { Texto = texto };
        var prediction = _predictionEngine.Predict(input);
        
        return prediction.Prediccion ? "Positivo" : "Negativo";
    }
}