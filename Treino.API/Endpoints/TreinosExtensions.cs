using Microsoft.AspNetCore.Mvc;
using Treino.API.Requests;
using TreinoAPI.DataBase;
using TreinoAPI.Exceptions;
using TreinoAPI.Modelos;

namespace Treino.API.Endpoints
{
    public static class TreinosExtensions
    {
        public static void AddEndpointsTreinos(this WebApplication app)
        {
            app.MapPost("/Treinos", ([FromServices] TreinoDAL treinoDAL, [FromBody] TreinoRequest treinoRequest) =>
            {
                var treino = new TreinoModel(treinoRequest.local, treinoRequest.distancia,
                    treinoRequest.data, treinoRequest.tempo);
                treinoDAL.AdicionarTreino(treino);
                return Results.Ok();
            });

            app.MapGet("/Treinos", ([FromServices] TreinoDAL treinoDAL) =>
            {
                try
                {
                    var treino = treinoDAL.MostrarTodosOsTreinos();
                    return Results.Ok(treino);
                }
                catch (TreinoNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return Results.Problem("Ocorreu um erro inesperado.");
                }
            });

            app.MapPut("/Treinos", ([FromServices] TreinoDAL treinoDAL, [FromBody] TreinoModel treino) =>
            {
                try
                {
                    var treinoAAtualizar = treinoDAL.MostrarTodosOsTreinos().Where(t => t.Id.Equals(treino.Id)).FirstOrDefault();

                    treinoAAtualizar!.Local = treino.Local;
                    treinoAAtualizar.Distancia = treino.Distancia;
                    treinoAAtualizar.Data = treino.Data;
                    treinoAAtualizar.Tempo = treino.Tempo;

                    treinoDAL.AtualizarTreino(treinoAAtualizar);
                    return Results.Ok();
                }
                catch (TreinoNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return Results.Problem("Ocorreu um erro inesperado.");
                }
            });

            app.MapDelete("/Treinos/{id}", ([FromServices] TreinoDAL treinoDAL, int id) =>
            {
                try
                {
                    treinoDAL.RemoverTreino(id);
                    return Results.NoContent();
                }
                catch (TreinoNotFoundException)
                {
                    return Results.NotFound("Nenhum treino foi encontrado com esse Id.");
                }
                catch (Exception)
                {
                    return Results.Problem("Ocorreu um erro inesperado.");
                }
            });

            app.MapGet("/Treinos/MaisRapido/2km", ([FromServices] TreinoDAL treinoDAL) =>
            {
                try
                {
                    return Results.Ok(treinoDAL.MostrarTreinoMaisRapido2km());
                }
                catch (TreinoNotFoundException)
                {
                    return Results.NotFound("Nenhum treino encontrado para 2km.");
                }
                catch (Exception)
                {
                    return Results.Problem("Ocorreu um erro inesperado.");
                }
            });

            app.MapGet("/Treinos/MaisDistante", ([FromServices] TreinoDAL treinoDAL) =>
            {
                try
                {
                    return Results.Ok(treinoDAL.MostrarTreinoMaisDistante());
                }
                catch (TreinoNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return Results.Problem("Ocorreu um erro inesperado.");
                }
            });
        
            app.MapGet("Treinos/MaisLongo", ([FromServices] TreinoDAL treinoDAL) =>
            {
                try
                {
                    return Results.Ok(treinoDAL.MostrarTreinoMaisLongo());
                }
                catch (TreinoNotFoundException ex)
                {
                    return Results.NotFound(ex.Message);
                }
                catch (Exception)
                {
                    return Results.Problem("Ocorreu um erro inesperado.");
                }
            });
        }
    }
}
