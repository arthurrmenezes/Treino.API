using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Users.API.Models;

namespace Users.API.Services;

public class EmailService
{
    private IConfiguration configuration;

    public EmailService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void EnviarEmail(string[] destinatario, string assunto, int userId, string codigoDeAtivacao)
    {
        Mensagem mensagem = new Mensagem(destinatario, assunto, userId, codigoDeAtivacao);
        var mensagemDeEmail = CriarCorpoDoEmail(mensagem);
        Enviar(mensagemDeEmail);
    }

    private void Enviar(MimeMessage mensagemDeEmail)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(configuration.GetValue<string>("EmailSettings:SmtpServer"),
                    configuration.GetValue<int>("EmailSettings:Port"), SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOUATH2");
                client.Authenticate(configuration.GetValue<string>("EmailSettings:From"),
                    configuration.GetValue<string>("EmailSettings:Password"));
                client.Send(mensagemDeEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar um email: {ex.Message}");
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }

    private MimeMessage CriarCorpoDoEmail(Mensagem mensagem)
    {
        var mensagemDeEmail = new MimeMessage();
        mensagemDeEmail.From.Add(new MailboxAddress(configuration.GetValue<string>("EmailSettings:From")));
        mensagemDeEmail.To.AddRange(mensagem.Destinatario);
        mensagemDeEmail.Subject = mensagem.Assunto;
        mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = mensagem.Conteudo
        };

        return mensagemDeEmail;
    }
}
