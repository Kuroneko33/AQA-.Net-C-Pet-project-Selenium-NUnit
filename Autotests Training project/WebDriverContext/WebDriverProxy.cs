using System;
using System.Collections.Generic;
using System.Text;

namespace Autotests_Training_project.WebDriverContext
{
    public class WebDriverProxy
    {
        public WebDriverProxy(string host, int port, string userName, string password)
        {
            Host = host;
            Port = port;
            UserName = userName;
            Password = password;
        }

        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
