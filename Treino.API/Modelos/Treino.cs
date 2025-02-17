namespace TreinoAPI.Modelos;

public class Treino
{
    public int Id { get; private set; }
    public string Local { get; private set; }
    public double Distancia { get; private set; }
    public DateTime Data { get; private set; }
    public TimeSpan Tempo { get; private set; }

    public Treino(string local, double distancia, DateTime data, TimeSpan tempo)
    {
        Local = local;
        Distancia = distancia;
        Data = data;
        Tempo = tempo;
    }
}
