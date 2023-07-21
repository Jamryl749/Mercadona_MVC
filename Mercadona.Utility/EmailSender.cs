/**
 *@file EmailSender.cs
 *brief A dummy email sender 
*/
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Mercadona.Utility
{
    public class EmailSender : IEmailSender
    {
        /**
        *@fn SendEmailAsync()
        *brief A dummy email sender method that always return a completed task to avoid problem with Identity
        */
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //logic to send email
            return Task.CompletedTask;
        }
    }
}
