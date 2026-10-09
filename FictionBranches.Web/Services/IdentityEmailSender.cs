using FictionBranches.Web.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace FictionBranches.Web.Services;

public class IdentityEmailSender(EmailService emailService) : IEmailSender<Fbuser>
{
    public Task SendPasswordResetLinkAsync(Fbuser user, string email, string resetLink)
        => SendAsync(email, "FictionBranches: Reset your password",
            $"<a href='{resetLink}'>Click here</a> to reset your password.");

    public Task SendPasswordResetCodeAsync(Fbuser user, string email, string resetCode)
        => SendAsync(email, "FictionBranches: Reset your password", $"Your reset code: {resetCode}");

    public Task SendConfirmationLinkAsync(Fbuser user, string email, string confirmationLink)
        => SendAsync(email, "FictionBranches: Confirm your email", $"<a href='{confirmationLink}'>Click here</a> to confirm  your email.");
    private Task SendAsync(string to, string subject, string html)
    {
        return emailService.SendEmailAsync([to], subject, html, isBodyHtml: true);
    }
}