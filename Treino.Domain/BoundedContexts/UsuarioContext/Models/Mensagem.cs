//using MimeKit;

//namespace Users.API.Models;

//public class Mensagem
//{
//    public List<MailboxAddress> Destinatario { get; set; }
//    public string Assunto { get; set; }
//    public string Conteudo { get; set; }

//    public Mensagem(IEnumerable<string> destinatario, string assunto, int userId, string codigoDeAtivacao)
//    {
//        this.Destinatario = new List<MailboxAddress>();
//        Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d)));
//        this.Assunto = assunto;
//        this.Conteudo = $"https://localhost:7125/ativarConta?UserId={userId}&CodigoDeAtivacao={codigoDeAtivacao}";
//    }
//}
