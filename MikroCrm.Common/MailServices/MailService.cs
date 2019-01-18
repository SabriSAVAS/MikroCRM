using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MikroCrm.Common.MailServices
{
    public class MailService
    {
        public static bool sendmail(string email, string subject, string body)
        {
            System.Net.Mail.MailMessage msj = new System.Net.Mail.MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                smtp.Credentials = new System.Net.NetworkCredential("rapor@arkombilisim.com", "92ReC70SAB");
                //smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Host = "mail.arkombilisim.com";


                msj.Body = body;
                msj.From = new MailAddress("rapor@arkombilisim.com", "Yeni Sipariş.", Encoding.UTF8);
                msj.To.Add(email);
                msj.Subject = subject;
                msj.SubjectEncoding = Encoding.UTF8;
                msj.BodyEncoding = Encoding.UTF8;
                msj.Body = body;

                smtp.Send(msj);
                smtp.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                smtp.Dispose();
            }
        }
        public static bool sendmail(string email, string subject, string body, byte[] binary,string attacmentName)
        {
            System.Net.Mail.MailMessage msj = new System.Net.Mail.MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                smtp.Credentials = new System.Net.NetworkCredential("rapor@arkombilisim.com", "92ReC70SAB");
                //smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Host = "mail.arkombilisim.com";


                msj.Body = body;
                msj.From = new MailAddress("rapor@arkombilisim.com", "Yeni Sipariş.", Encoding.UTF8);
                msj.To.Add(email);
                msj.Subject = subject;
                msj.SubjectEncoding = Encoding.UTF8;
                msj.BodyEncoding = Encoding.UTF8;
                msj.Attachments.Add(new Attachment(new MemoryStream(binary), attacmentName));
                msj.Body = body;

                smtp.Send(msj);
                smtp.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                smtp.Dispose();
            }
        }
    }
}
