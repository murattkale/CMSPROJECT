﻿using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;


public class SendMail : ISendMail
{
    public async void SendMails(MailModel postModel)
    {
        try
        {
            MailMessage mail = new MailMessage(); //yeni bir mail nesnesi Oluşturuldu.
            mail.IsBodyHtml = true; //mail içeriğinde html etiketleri kullanılsın mı?
            foreach (var item in postModel.Alicilar)
            {
                mail.To.Add(item); //Kime mail gönderilecek.
            }

            //mail kimden geliyor, hangi ifNamee görünsün?
            mail.From = new MailAddress(postModel.KimdenMail, postModel.KimdenText, System.Text.Encoding.UTF8);
            mail.Subject = postModel.Konu;//mailin konusu

            if (postModel.cc != null)
                foreach (var item in postModel.cc)
                {
                    mail.CC.Add(item); //CC.
                }

            //mailin içeriği.. Bu alan isteğe göre genişletilip daraltılabilir.
            mail.Body = postModel.Icerik;
            mail.IsBodyHtml = true;
            SmtpClient smp = new SmtpClient();
            //smp.UseDefaultCredentials = true;
            smp.Credentials = new NetworkCredential("bilgi@kazaskerfenbilimleri.com", "NCbg78G0");
            smp.Port = 587;
            //smp.Host = "mx-out04.natrohost.com";//mail üzerinden gönderiliyor.
            smp.Host = "mail.kazaskerfenbilimleri.com";//mail üzerinden gönderiliyor.
            //mailin gönderileceği Nameres ve şifresi
            //smp.EnableSsl = true;
            smp.Send(mail);//mail isimli mail gönderiliyor.

        }
        catch (Exception ex)
        {

        }




    }




}

