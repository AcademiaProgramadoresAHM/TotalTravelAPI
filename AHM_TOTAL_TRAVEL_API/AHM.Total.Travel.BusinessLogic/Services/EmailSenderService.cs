using AHM.Total.Travel.Common.Models;
using ConciertosProyecto.BusinessLogic;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using MimeKit;
using MailKit;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class EmailSenderService
    {
        private readonly IConfiguration _config;

        public EmailSenderService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public ServiceResult RetrievePassword(EmailDataViewModel emailData)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_config["Jwt:Company"], _config["Jwt:Mail"]));
                message.To.Add(new MailboxAddress(emailData.ToName, emailData.To));
                message.Subject = emailData.Subject;
                message.Body = new TextPart("plain")
                {
                    Text = emailData.BodyData

                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())                
                {
                    client.Connect(_config["ApiGmail:Host"], 
                        int.Parse(_config["ApiGmail:Port"]), 
                        false);
                    client.Authenticate(_config["ApiGmail:Mail"], "ApiGmail:Password");
                    client.Send(message);
                    client.Disconnect(true);
                }
                return new ServiceResult().Ok(data: "Correo enviado con exito");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ServiceResult().BadRequest(message: "Ocurrio un error al enviar el email");
            }
        }
    }
}
