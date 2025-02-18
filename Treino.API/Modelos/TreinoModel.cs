namespace TreinoAPI.Modelos;
public class TreinoModel
{
    public int Id { get; set; }
    public string Local { get; set; }
    public double Distancia { get; set; }
    public DateTime Data { get; set; }
    public TimeSpan Tempo { get; set; }

    public TreinoModel(string local, double distancia, DateTime data, TimeSpan tempo)
    {
        Local = local;
        Distancia = distancia;
        Data = data;
        Tempo = tempo;
    }
}
