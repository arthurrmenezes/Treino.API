using Microsoft.AspNetCore.Mvc;
using Treino.API.Requests;
using TreinoAPI.DataBase;
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
                var treino = treinoDAL.MostrarTodosOsTreinos();

                if (treino is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(treino);
            });

            app.MapPut("/Treinos", ([FromServices] TreinoDAL treinoDAL, [FromBody] TreinoModel treino) =>
            {
                var treinoAAtualizar = treinoDAL.MostrarTodosOsTreinos().Where(t => t.Id.Equals(treino.Id)).FirstOrDefault();
                if (treinoAAtualizar is null)
                {
                    return Results.NotFound();
                }

                treinoAAtualizar.Local = treino.Local;
                treinoAAtualizar.Distancia = treino.Distancia;
                treinoAAtualizar.Data = treino.Data;
                treinoAAtualizar.Tempo = treino.Tempo;

                treinoDAL.AtualizarTreino(treinoAAtualizar);
                return Results.Ok();
            });

            app.MapDelete("/Treinos/{id}", ([FromServices] TreinoDAL treinoDAL, int id) =>
            {
                var treino = treinoDAL.MostrarTodosOsTreinos().Where(t => t.Id.Equals(id)).FirstOrDefault();
                if (treino is null)
                {
                    return Results.NotFound();
                }
                treinoDAL.RemoverTreino(id);
                return Results.NoContent();
            });
        }
    }
}
