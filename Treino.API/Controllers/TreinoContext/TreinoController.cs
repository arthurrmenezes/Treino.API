using Microsoft.AspNetCore.Mvc;
using System.Web.Http.OData;
using TreinoApp.Application.Services.TreinoContext;
using TreinoApp.Domain.BoundedContexts.UsuarioContext.DataTransferObject;

namespace TreinoApp.WebApi.Controllers.TreinoContext;

[ApiController]
[Route("[controller]")]
public class TreinoController : ControllerBase
{
    private TreinoService _treinoService;

    public TreinoController(TreinoService treinoService)
    {
        this._treinoService = treinoService;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarTreino([FromBody] CreateTreinoDto treinoDto)
    {
        await _treinoService.AdicionarTreino(treinoDto);
        return Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTreinos()
    {
        var treinos = await _treinoService.GetTodosOsTreinos();
        return Ok(treinos);

    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> AtualizarTreino(int id, [FromBody] Delta<CreateTreinoDto> parametroTreinoDto)
    {
        try
        {
            var treinoDto = await _treinoService.GetTreinoParaAtualizar(id);
            
            parametroTreinoDto.Patch(treinoDto);

            await _treinoService.AtualizarTreino(id, treinoDto);
            return NoContent();
        }
        catch (Exception exception)
        {
            return NotFound("Erro ao fazer o patch " + exception.Message);
        }
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarTreino(int id)
    {
        await _treinoService.RemoverTreino(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetTreinoPorId(int id)
    {
        var treino = await _treinoService.GetTreinoPorId(id);
        return Ok(treino);
    }

    [HttpGet("MaisRapido/2km")]
    public async Task<IActionResult> GetTreinoMaisRapido2km()
    {
        var treino = await _treinoService.GetTreinoMaisRapido2km();
        return Ok(treino);
    }

    [HttpGet("MaisDistante")]
    public async Task<IActionResult> GetTreinoMaisDistante()
    {
        var treino = await _treinoService.GetTreinoMaisDistante();
        return Ok(treino);
    }

    [HttpGet("MaisLongo")]
    public async Task<IActionResult> GetTreinoMaisLongo()
    {
        var treino = await _treinoService.GetTreinoMaisLongo();
        return Ok(treino);
    }
}
