using TreinoAPI.Exceptions;
using TreinoAPI.Modelos;

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
        treinoContext.Treinos.Update(treino);
        treinoContext.SaveChanges();
    }

    public void RemoverTreino(int id)
    {
        var treino = treinoContext.Treinos.Where(t => t.Id.Equals(id)).FirstOrDefault();
        treinoContext.Treinos.Remove(treino!);
        treinoContext.SaveChanges();
    }
}
