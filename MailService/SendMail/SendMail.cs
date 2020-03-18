using System;
using System.Net;
using System.Net.Mail;


public class SendMail : ISendMail
{
    public async void Send(MailModelCustom postModel)
    {
        try
        {
            MailMessage mail = new MailMessage(); //yeni bir mail nesnesi Oluşturuldu.
            mail.IsBodyHtml = true; //mail içeriğinde html etiketleri kullanılsın mı?
            foreach (var item in postModel.Alicilar)
            {
                mail.To.Add(item.Trim()); //Kime mail gönderilecek.
            }

            //mail kimden geliyor, hangi ifNamee görünsün?
            mail.From = new MailAddress(postModel.SmtpMail, postModel.MailGorunenAd, System.Text.Encoding.UTF8);
            mail.Subject = postModel.Konu;//mailin konusu

            if (postModel.cc != null)
                foreach (var item in postModel.cc)
                {
                    mail.CC.Add(item.Trim()); //CC.
                }

            //mailin içeriği.. Bu alan isteğe göre genişletilip daraltılabilir.
            mail.Body = postModel.Icerik;
            mail.IsBodyHtml = true;
            SmtpClient smp = new SmtpClient();
            smp.UseDefaultCredentials = postModel.SmtpUseDefaultCredentials == null ? false : (postModel.SmtpUseDefaultCredentials == true ? true : false);
            //mailin gönderileceği Nameres ve şifresi
            smp.Credentials = new NetworkCredential(postModel.SmtpMail, postModel.SmtpMailPass);
            smp.Port = postModel.SmtpPort.ToInt();
            smp.Host = postModel.SmtpHost;//gmail üzerinden gönderiliyor.
            smp.EnableSsl = postModel.SmtpSSL == null ? false : (postModel.SmtpSSL==true?true:false);
            smp.Send(mail);//mail isimli mail gönderiliyor.

        }
        catch (Exception ex)
        {

        }




    }


}


