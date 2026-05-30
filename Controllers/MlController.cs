using ApiTareas.Models;
using ApiTareas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTareas.Controllers;

[ApiController]
[Route("api/ml")]
public class MlController : ControllerBase
{
    private readonly MlService _mlService;

    public MlController(MlService mlService)
    {
        _mlService = mlService;
    }

    [HttpPost("sentimiento")]
    public ActionResult<SentimientoResponse> AnalizarSentimiento([FromBody] SentimientoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Comentario))
        {
            return BadRequest("El comentario no puede estar vacio.");
        }

        var sentimiento = _mlService.PredecirSentimiento(request.Comentario);

        var response = new SentimientoResponse
        {
            Comentario = request.Comentario,
            Sentimiento = sentimiento
        };

        return Ok(response);
    }
}
