using System.ComponentModel.DataAnnotations;

namespace Users.API.DataBase.Request;

public class AtivaContaRequest
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public string CodigoDeAtivacao { get; set; }
}
