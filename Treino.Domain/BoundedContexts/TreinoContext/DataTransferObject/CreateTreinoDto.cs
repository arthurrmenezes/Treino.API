using System.ComponentModel.DataAnnotations;

namespace TreinoApp.Domain.BoundedContexts.UsuarioContext.DataTransferObject;

public class CreateTreinoDto
{
    [Required]
    public string Local { get; set; }
    [Required]
    public double Distancia { get; set; }
    [Required]
    public TimeSpan Tempo { get; set; }
    [Required]
    public DateTime Data { get; set; }

    public CreateTreinoDto() { }

    public CreateTreinoDto(string local, double distancia, TimeSpan tempo, DateTime data)
    {
        Local = local;
        Distancia = distancia;
        Tempo = tempo;
        Data = data;
    }
}
