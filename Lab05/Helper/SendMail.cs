using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Lab05.Helper
{
    public static class SendMail
    {
        public static void Send(string title, string content, CUSTOMER c, int id)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("tungnguyenhutech@gmail.com");

                mail.Subject = title;
                mail.Body = content;

                mail.IsBodyHtml = true;
                mail.Body += "<img src=\"http://localhost:1713/Home/Logo?IDLogo=" + id+"&LogoID="+c.IdCustomer+ "\" width=\"1px\" height=\"1px\"/>";
                mail.To.Add(c.CustomerEmail);

                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("tungnguyenhutech@gmail.com", "Vinh@2981995");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
            }
        }

    }
}