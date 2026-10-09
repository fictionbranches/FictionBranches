using System.Net;
using System.Net.Mail;
using FictionBranches.Web.Configuration;
using Microsoft.Extensions.Options;

namespace FictionBranches.Web.Services;

public class EmailService(IOptionsMonitor<FictionBranchesOptions> config)
{
    public Task SendEmailAsync(List<string> to,
        string subject,
        string body,
        List<string>? cc = null,
        List<string>? bcc = null,
        bool isBodyHtml = true)
    {
        var smtpClient = new SmtpClient(config.CurrentValue.SmtpServer, config.CurrentValue.SmtpPort)
        {
            EnableSsl = true,
        };
        if (!string.IsNullOrEmpty(config.CurrentValue.SmtpUsername))
        {
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials =
                new NetworkCredential(config.CurrentValue.SmtpUsername, config.CurrentValue.SmtpPassword);
        }

        var mailMessage = new MailMessage
        {
            From = new MailAddress(config.CurrentValue.SmtpSendAs),
            Subject = subject,
            Body = body,
            IsBodyHtml = isBodyHtml,
        };

        foreach (var addr in to.Where(addr => !string.IsNullOrWhiteSpace(addr)))
        {
            mailMessage.To.Add(new MailAddress(addr));
        }

        if (cc != null)
        {
            foreach (var addr in cc.Where(addr => !string.IsNullOrWhiteSpace(addr)))
            {
                mailMessage.CC.Add(new MailAddress(addr));
            }
        }

        if (bcc != null)
        {
            foreach (var addr in bcc.Where(addr => !string.IsNullOrWhiteSpace(addr)))
            {
                mailMessage.Bcc.Add(new MailAddress(addr));
            }
        }

        return smtpClient.SendMailAsync(mailMessage);
    }
}