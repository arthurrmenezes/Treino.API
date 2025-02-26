    using System.ComponentModel.DataAnnotations;

namespace Treino.API.Models;
public class TreinoModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Local { get; set; }
    [Required]
    public double Distancia { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public TimeSpan Tempo { get; set; }

    public TreinoModel(string local, double distancia, DateTime data, TimeSpan tempo)
    {
        Local = local;
        Distancia = distancia;
        Data = data;
        Tempo = tempo;
    }
}
