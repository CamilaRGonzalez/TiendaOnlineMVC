using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("armando_barreda_67@outlook.com", "Armando456");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.office365.com";
        }

        public void ArmarCorreo(string emailDestino, string asunto,string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("armando_barreda_67@outlook.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;
        }

        public void EnviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
