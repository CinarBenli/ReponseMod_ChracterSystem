using ReponseChracterSystemV2.Model;
using Rocket.API;
using System.Collections.Generic;

namespace ReponseChracterSystemV2
{
    public class Config : IRocketPluginConfiguration
    {
        public string ServerName;
        public string Logo;
        public string DiscordWebhookLink;
        public ushort IdentityID;
        public int NameLength;
        public int SurnameLength;
        public int AgeMax;
        public int WeightMax;
        public int HeightMax;
        public List<Kayıtlılar> Kayıtlı;

        public void LoadDefaults()
        {
            ServerName = "Reponse";
            Logo = "https://media.discordapp.net/attachments/959142220366237796/962008357990977626/122.png";
            DiscordWebhookLink = "http";
            IdentityID = 5115;
            NameLength = 10;
            SurnameLength = 10;
            AgeMax = 50;
            WeightMax = 90;
            HeightMax = 200;
            Kayıtlı = new List<Kayıtlılar>();
        }
    }
}