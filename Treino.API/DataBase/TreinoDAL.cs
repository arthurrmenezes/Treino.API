using TreinoAPI.Modelos;

namespace TreinoAPI.DataBase;

public class TreinoDAL
{
    private TreinoContext treinoContext;

    public TreinoDAL()
    {
        treinoContext = new TreinoContext();
    }

    public void AdicionarTreino(Treino treino)
    {
        treinoContext.Treinos.Add(treino);
        treinoContext.SaveChanges();
    }

    public IEnumerable<Treino> MostrarTreino()
    {
        if (treinoContext.Treinos.Count() == 0)
        {
            throw new Exception();
        }
        return treinoContext.Treinos.ToList();
    }

    // corrida mais rapida
    // maior distancia corrida
    // total de corridas no mes X... passar X como parametro
}
