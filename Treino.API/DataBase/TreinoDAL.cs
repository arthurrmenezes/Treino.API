using Treino.API.Models;
using TreinoAPI.Exceptions;

namespace TreinoAPI.DataBase;

public class TreinoDAL
{
    private readonly TreinoContext treinoContext;

    public TreinoDAL(TreinoContext treinoContext)
    {
        this.treinoContext = treinoContext;
    }

    public void AdicionarTreino(TreinoModel treino)
    {
        treinoContext.Treinos.Add(treino);
        treinoContext.SaveChanges();
    }

    public IEnumerable<TreinoModel> MostrarTodosOsTreinos()
    {
        if (treinoContext.Treinos.Count() == 0)
        {
            throw new TreinoNotFoundException("Nenhum treino foi cadastrado.");
        }
        return treinoContext.Treinos.ToList();
    }

    public void AtualizarTreino(TreinoModel treino)
    {
        if (treino is null)
        {
            throw new TreinoNotFoundException("Nenhum treino foi encontrado.");
        }
        treinoContext.Treinos.Update(treino);
        treinoContext.SaveChanges();
    }

    public void RemoverTreino(int id)
    {
        var treino = treinoContext.Treinos.Where(t => t.Id.Equals(id)).FirstOrDefault();
        if (treino is null)
        {
            throw new TreinoNotFoundException("Nenhum treino foi encontrado com esse Id.");
        }
        treinoContext.Treinos.Remove(treino!);
        treinoContext.SaveChanges();
    }

    public TreinoModel GetTreinoPorId(int id)
    {
        var treino = treinoContext.Treinos.FirstOrDefault(t => t.Id.Equals(id));
        if (treino is null)
        {
            throw new TreinoNotFoundException($"Nenhum treino com Id {id} foi encontrado.");
        }
        treinoContext.Update(treino);
        treinoContext.SaveChanges();
        return treino;
    }

    public TreinoModel MostrarTreinoMaisRapido2km()
    {
        var treinoMaisRapido = treinoContext.Treinos.OrderBy(t => t.Tempo)
            .Where(t => t.Distancia >= 2.00)
            .FirstOrDefault();

        if (treinoMaisRapido is null)
        {
            throw new TreinoNotFoundException("Nenhum treino acima de 2km foi encontrado.");
        }
        return treinoMaisRapido;
    }

    public TreinoModel MostrarTreinoMaisDistante()
    {
        var treinoMaisDistante = treinoContext.Treinos.OrderByDescending(t => t.Distancia).FirstOrDefault();
        if (treinoMaisDistante is null)
        {
            throw new TreinoNotFoundException("Nenhum treino foi encontrado.");
        }
        return treinoMaisDistante;
    }

    public TreinoModel MostrarTreinoMaisLongo()
    {
        var treinoMaisLongo = treinoContext.Treinos.OrderByDescending(t => t.Tempo).FirstOrDefault();
        if (treinoMaisLongo is null)
        {
            throw new TreinoNotFoundException("Nenhum treino foi encontrado.");
        }
        return treinoMaisLongo;
    }
}