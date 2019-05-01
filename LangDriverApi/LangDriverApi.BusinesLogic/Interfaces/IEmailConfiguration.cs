using System;
using System.Collections.Generic;
using System.Text;

namespace LangDriverApi.BusinesLogic.Interfaces
{
    public interface IEmailConfiguration
    {
        string SmtpServer { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; set; }
        string SmtpPassword { get; set; }
    }
}
