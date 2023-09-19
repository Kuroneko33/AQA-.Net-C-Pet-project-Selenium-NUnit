using System;
using System.Collections.Generic;
using System.Text;

namespace Autotests_Training_project
{
    public static class Authors
    {
        public class Levizarovich_A_O
        {
            public const string Name = "Левизарович А.О.";
            public const string Email = "anton.leviz@gmail.com";

            public class GitHub
            {
                public const string UserName = "Антон";
                public const string UserId = "Kuroneko33";
                public const string Link = "https://github.com/" + UserId;
            }
            public class Telegram
            {
                public const string UserName = "Антон";
                public const string UserId = "@Kuroneko33";
                public const string Link = "setlink/" + UserId;
            }
            public class LinkedIn
            {
                public const string UserName = "Антон";
                public const string UserId = "@setlink";
                public const string Link = "setlink/" + UserId;
            }
            public class VK
            {
                public const string UserName = "Антон Левизарович";
                public const string UserId = "@setlink";
                public const string Link = "setlink/" + UserId;
            }

            public new const string ToString = 
                "Name: " + Name + 
                ", \nEmail: " + Email +
                ", \nGitHub: " + GitHub.Link +
                ", \nTelegram: " + Telegram.Link +
                ", \nLinkedIn: " + LinkedIn.Link +
                ", \nVK: " + VK.Link;
        }
    }
}
