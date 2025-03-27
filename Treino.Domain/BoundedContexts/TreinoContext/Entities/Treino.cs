using System.ComponentModel.DataAnnotations;

namespace TreinoApp.Domain.BoundedContexts.UsuarioContext.Entities;

public class Treino
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Local { get; set; }
    [Required]
    public double Distancia { get; set; }
    [Required]
    public TimeSpan Tempo { get; set; }
    [Required]
    public DateTime Data { get; set; }

    public Treino(string local, double distancia, TimeSpan tempo, DateTime data)
    {
        Local = local;
        Distancia = distancia;
        Tempo = tempo;
        Data = data;
    }
}
