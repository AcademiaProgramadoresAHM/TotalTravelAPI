using AHM.Total.Travel.Common.Models;
using ConciertosProyecto.BusinessLogic;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using MimeKit;
using MailKit;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using AHM.Total.Travel.DataAccess;
using AHM.Total.Travel.DataAccess.Repositories;

namespace AHM.Total.Travel.BusinessLogic.Services
{
    public class EmailSenderService
    {
        private readonly IConfiguration _config;

        public EmailSenderService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public RequestStatus EmailVerification(String email)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@Email",email, DbType.String, ParameterDirection.Input);

            using var db = new SqlConnection(TotalTravelContext.ConnectionString);

            return db.QueryFirst<RequestStatus>(ScriptDataBase.UDP_tbUsuarios_EmailVerification, parameters, commandType: CommandType.StoredProcedure);
        }

        public ServiceResult RetrievePassword(EmailDataViewModel emailData)
        {
            try
            {
                Random r = new Random();
                int rInt = r.Next(100000, 999999);
                emailData.Subject = "Recuperación de contraseña - Agencia TotalTravel";
                emailData.BodyData = "Su codigo de recuperación es: " + rInt;

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_config["ApiGmail:Company"], _config["ApiGmail:Mail"]));
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
                    client.Authenticate(_config["ApiGmail:Mail"], _config["ApiGmail:Password"]);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return new ServiceResult().Ok(data: rInt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ServiceResult().BadRequest(message: "Ocurrio un error al enviar el email");
            }
        }

        public ServiceResult ContactEmail(EmailDataViewModel emailData)
        {
            try
            {
                
                emailData.Subject = "Contáctanos - Agencia Total Travel";

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(emailData.ToName, emailData.To));
                message.To.Add(new MailboxAddress(_config["ApiGmail:Company"], _config["ApiGmail:Mail"]));
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
                    client.Authenticate(_config["ApiGmail:Mail"], _config["ApiGmail:Password"]);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return new ServiceResult().Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ServiceResult().BadRequest(message: "Ocurrio un error al enviar el email");
            }
        }

        public ServiceResult ConfirmationReservation(EmailDataViewModel emailData, string reservation)
        {
            try
            {
                
                emailData.Subject = "Reservación Confirmada - Agencia TotalTravel";
                emailData.BodyData = "Usted ha confirmado su reservación para" + reservation;

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_config["ApiGmail:Company"], _config["ApiGmail:Mail"]));
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
                    client.Authenticate(_config["ApiGmail:Mail"], _config["ApiGmail:Password"]);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return new ServiceResult().Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ServiceResult().BadRequest(message: "Ocurrio un error al enviar el email");
            }
        }
    }
}
