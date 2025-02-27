using Microsoft.AspNetCore.Mvc;
using Treino.API.DataBase.Dtos.Treino;
using Treino.API.Services;
using TreinoAPI.Exceptions;

namespace Treino.API.Endpoints;

[ApiController]
[Route("[controller]")]
public class TreinoController : ControllerBase
{
    private TreinoService treinoService;

    public TreinoController(TreinoService treinoService)
    {
        this.treinoService = treinoService;
    }

    [HttpPost]
    public IActionResult AdicionarTreino([FromBody] TreinoDto treinoDto)
    {
        treinoService.AdicionarTreino(treinoDto);
        return Created();
        // return CreatedAtAction(nameof(GetTreinoPorId), new { id = treinoDto.Id }, treinoDto);
    }

    [HttpGet]
    public IActionResult GetAllTreinos()
    {
        try
        {
            var treinos = treinoService.MostrarTodosOsTreinos();
            return Ok(treinos);
        }
        catch (TreinoNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return Problem("Ocorreu um erro inesperado.");
        }
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarTreino(int id, [FromBody] TreinoDto treinoDto)
    {
        try
        {            
            treinoService.AtualizarTreino(id, treinoDto);
            return NoContent();
        }
        catch (TreinoNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return Problem("Ocorreu um erro inesperado.");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarTreino(int id)
    {
        try
        {
            treinoService.RemoverTreino(id);
            return NoContent();
        }
        catch (TreinoNotFoundException)
        {
            return NotFound("Nenhum treino foi encontrado com esse Id.");
        }
        catch (Exception)
        {
            return Problem("Ocorreu um erro inesperado.");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetTreinoPorId(int id)
    {
        try
        {
            var treino = treinoService.GetTreinoPorId(id);
            return Ok(treino);
        }
        catch (TreinoNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return Problem("Ocorreu um erro inesperado.");
        }
    }

    [HttpGet("MaisRapido/2km")]
    public IActionResult GetTreinoMaisRapido2km()
    {
        try
        {
            return Ok(treinoService.MostrarTreinoMaisRapido2km());
        }
        catch (TreinoNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return Problem("Ocorreu um erro inesperado.");
        }
    }

    [HttpGet("MaisDistante")]
    public IActionResult GetTreinoMaisDistante()
    {
        try
        {
            return Ok(treinoService.MostrarTreinoMaisDistante());
        }
        catch (TreinoNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return Problem("Ocorreu um erro inesperado.");
        }
    }

    [HttpGet("MaisLongo")]
    public IActionResult GetTreinoMaisLongo()
    {
        try
        {
            return Ok(treinoService.MostrarTreinoMaisLongo());
        }
        catch (TreinoNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return Problem("Ocorreu um erro inesperado.");
        }
    }
}
