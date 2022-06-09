using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReponseChracterSystemV2.Services
{
    internal class Discord
    {
        public static void Webhook(string webhook, string kullanici_adi, string baslik, string icerik, string avatarUrl)
        {
            try
            {
                WebRequest wr = (HttpWebRequest)WebRequest.Create(webhook);
                wr.ContentType = "application/json";
                wr.Method = "POST";
                using (var sw = new StreamWriter(wr.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(new
                    {
                        username = kullanici_adi,
                        avatar_url = avatarUrl,
                        embeds = new[]
                        {
                            new
                            {
                                description = icerik,
                                type = "rich",
                                title = baslik,
                                color = 4052285,
                            }

                        }
                    });
                    sw.Write(json);
                }
                var response = (HttpWebResponse)wr.GetResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
       
    }
}
