using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Leaf.xNet;

namespace MediaMarkt
{
    class Program
    {

        public static void sendDiscordWebhook()
        {
            using (WebClient web = new WebClient())
            {
                NameValueCollection discordValues = new NameValueCollection();
                discordValues.Add("PS5", "PS5");
                discordValues.Add("avatar_url", ""); //avater url (direct link jpg)
                discordValues.Add("content", "@everyone PS5 is available on MEDIAMARKT!");
                web.UploadValues("webhook", discordValues); //webhook here
            }
        }
        static void Main(string[] args)
        {
            HttpRequest req = new HttpRequest();
            for (; ; )
            {
                Thread.Sleep(10000); //Checkes in ms e.g 10000 = 10000ms = 10s
                string mediamarkt = req.Get("https://www.mediamarkt.at/de/product/_sony-playstation%C2%AE5-digital-1797340.html").ToString();
                if (mediamarkt.Contains("Dieser Artikel ist aktuell nicht verfügbar."))
                {

                    Console.WriteLine("Nicht verfügbar");
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        sendDiscordWebhook();

                    }

                    Console.WriteLine("verfügbar");
                }
            }
        }
    }
}
