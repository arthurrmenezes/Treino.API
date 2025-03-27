using System.ComponentModel.DataAnnotations;

namespace TreinoApp.Domain.BoundedContexts.UsuarioContext.Entities;

public class Usuario
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string Surname { get; set; }
    public DateTime DataDeCriacao { get; init; } = DateTime.UtcNow;


    [Required]
    public double Distancia { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public TimeSpan Tempo { get; set; }

}
