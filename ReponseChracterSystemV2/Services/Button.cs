using ReponseChracterSystemV2.Model;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReponseChracterSystemV2.Services
{
    internal class Button
    {
        DateTime tarih;
        internal static void button(Player player, string buttonName)
        {
            UnturnedPlayer pl = UnturnedPlayer.FromPlayer(player);
            switch (buttonName)
            {
                case "Oluştur":
                    var değer = Class1.Instance.KayıtOl.FirstOrDefault(x => x.KayıtOlacakCSteamID == pl.CSteamID);

                    if (değer.KayıtOlacakAd == null || değer.KayıtOlacakSoyad == null || değer.KayıtOlacakYaş == 0 || değer.KayıtOlacakKilo == 0 || değer.KayıtOlacakBoy == 0 )
                    {

                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "karakteruyar", $"<color=red><B>İstenilen Bilgileri Doğru Girdiğinizden Emin Olunuz");
                        return;
                    }

                    var SıraAl = Class1.Instance.Configuration.Instance.Kayıtlı.Count;
                    var dğ = SıraAl += 1;
                    Class1.Instance.Configuration.Instance.Kayıtlı.Add(new Kayıtlılar
                    {
                        KayıtlıCSteamID = değer.KayıtOlacakCSteamID,
                        KayıtlıAd = değer.KayıtOlacakAd,
                        KayıtlıSoyad = değer.KayıtOlacakSoyad,
                        KayıtlıBoy = değer.KayıtOlacakBoy,
                        KayıtlıKilo = değer.KayıtOlacakKilo,
                        KayıtlıYaş = değer.KayıtOlacakYaş,
                        KayıtlıSıraNo = dğ,
                    });

                    if (Class1.Instance.Configuration.Instance.DiscordWebhookLink != "http")
                    {
                        var tarih = DateTime.Now.Date;
                        Discord.Webhook(
                            Class1.Instance.Configuration.Instance.DiscordWebhookLink,
                            "Reponse Mod - Chracter Log",
                            "Unturned Chracter System Log",
                            $"**The User with the {pl.CharacterName} ID Has Successfully Registered!** \n **Name/Surname:** {değer.KayıtOlacakAd} {değer.KayıtOlacakSoyad} \n **Age:** {değer.KayıtOlacakYaş} \n **Weight:** {değer.KayıtOlacakBoy} \n **Height:** {değer.KayıtOlacakKilo} \n **Date:** {tarih} \n Sıra No: {dğ}",
                            pl.SteamProfile.AvatarIcon.ToString()
                            );
                    }
                    Class1.Instance.KayıtOl.Remove(değer);
                    EffectManager.sendUIEffectVisibility(66, pl.Player.channel.owner.transportConnection, true, "Karakter", false);
                    Class1.Instance.Configuration.Save();
                    pl.Kick("You Have Successfully Registered, Please Log In Again");
                    break;
            }
        }
    }
}
