using Microsoft.AspNetCore.Mvc;
using Treino.API.DataBase.Dtos.Treino;
using Treino.API.Models;
using Treino.API.Services;
using TreinoAPI.Exceptions;

namespace Treino.API.Endpoints;

[ApiController]
[Route("[controller]")]
public class TreinoController : ControllerBase
{
    [HttpPost]
    public IActionResult AdicionarTreino([FromServices] TreinoService treinoDAL, [FromBody] TreinoDTO treinoDto)
    {
        TreinoModel treino = new TreinoModel(treinoDto.Local, treinoDto.Distancia,
            treinoDto.Data, treinoDto.Tempo);
        treinoDAL.AdicionarTreino(treino);
        return CreatedAtAction(nameof(GetAllTreinos), new { id = treino.Id }, treino);
    }

    [HttpGet]
    public IActionResult GetAllTreinos([FromServices] TreinoService treinoDAL)
    {
        try
        {
            var treinos = treinoDAL.MostrarTodosOsTreinos();
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
    public IActionResult AtualizarTreino(int id, [FromServices] TreinoService treinoDAL, [FromBody] TreinoDTO treinoDto)
    {
        try
        {
            var treinoAAtualizar = treinoDAL.GetTreinoPorId(id);

            treinoAAtualizar.Local = treinoDto.Local;
            treinoAAtualizar.Distancia = treinoDto.Distancia;
            treinoAAtualizar.Data = treinoDto.Data;
            treinoAAtualizar.Tempo = treinoDto.Tempo;

            treinoDAL.AtualizarTreino(treinoAAtualizar);
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
    public IActionResult DeletarTreino([FromServices] TreinoService treinoDAL, int id)
    {
        try
        {
            treinoDAL.RemoverTreino(id);
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
    public IActionResult GetTreinoPorId([FromServices] TreinoService treinoDAL, int id)
    {
        try
        {
            var treino = treinoDAL.GetTreinoPorId(id);
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
    public IActionResult GetTreinoMaisRapido2km([FromServices] TreinoService treinoDAL)
    {
        try
        {
            return Ok(treinoDAL.MostrarTreinoMaisRapido2km());
        }
        catch (TreinoNotFoundException)
        {
            return NotFound("Nenhum treino encontrado para 2km.");
        }
        catch (Exception)
        {
            return Problem("Ocorreu um erro inesperado.");
        }
    }

    [HttpGet("MaisDistante")]
    public IActionResult GetTreinoMaisDistante([FromServices] TreinoService treinoDAL)
    {
        try
        {
            return Ok(treinoDAL.MostrarTreinoMaisDistante());
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
    public IActionResult GetTreinoMaisLongo([FromServices] TreinoService treinoDAL)
    {
        try
        {
            return Ok(treinoDAL.MostrarTreinoMaisLongo());
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
