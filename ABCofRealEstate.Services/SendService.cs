using ABCofRealEstate.Services.Models.Sends;
using MailKit.Net.Smtp;
using MimeKit;

namespace ABCofRealEstate.Services;

public class SendService
{
    public async Task<BaseResponse<string>> SendEmail(SendEmailContactRequest sendEmailContactRequest)
    {
        using var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress(sendEmailContactRequest.FullName, "maks.khromakov@mail.ru"));
        emailMessage.To.Add(new MailboxAddress("Real Estate Agency", "maks.khromakov@mail.ru"));
        emailMessage.Subject = sendEmailContactRequest.FullName;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = string.Concat("Я, ", sendEmailContactRequest.FullName, ". Мой номер телефона: ", sendEmailContactRequest.NumberPhone, ". Почта: ", sendEmailContactRequest.Email, ". ", sendEmailContactRequest.Message)
        };

        using (var client = new SmtpClient())
        {
            client.LocalDomain = "localhost";
            await client.ConnectAsync("smtp.mail.ru", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync("maks.khromakov@mail.ru", "WM3Kw2dWjqCqxsVue9Pi");
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }

        return new BaseResponse<string>() { IsSuccess = true };
    }
    public async Task<BaseResponse<string>> SendEmail(SendEmailContactUsRequest sendEmailContactRequest)
    {
        using var emailMessage = new MimeMessage();
        var fullName = $"{sendEmailContactRequest.FirstName} {sendEmailContactRequest.LastName}";
        emailMessage.From.Add(new MailboxAddress(fullName, "maks.khromakov@mail.ru"));
        emailMessage.To.Add(new MailboxAddress("Real Estate Agency", "maks.khromakov@mail.ru"));
        emailMessage.Subject = sendEmailContactRequest.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = string.Concat("Я, ", fullName, ". Мой номер телефона: ", sendEmailContactRequest.NumberPhone, ". Почта: ", sendEmailContactRequest.Email, ". ", sendEmailContactRequest.Message)
        };

        using (var client = new SmtpClient())
        {
            client.LocalDomain = "localhost";
            await client.ConnectAsync("smtp.mail.ru", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync("maks.khromakov@mail.ru", "WM3Kw2dWjqCqxsVue9Pi");
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }

        return new BaseResponse<string>() { IsSuccess = true };
    }
}
