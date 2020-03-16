using System;
using System.Collections.Generic;
using System.Text;


public interface ISendMail
{
    void SendMails(templateMailModel postModel);
    void Send(MailModelCustom postModel);
}

