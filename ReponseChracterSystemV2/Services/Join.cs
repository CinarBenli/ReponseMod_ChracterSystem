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
    internal class Join
    {
        internal static void join(UnturnedPlayer player)
        {
            var değer = Class1.Instance.Configuration.Instance.Kayıtlı.FirstOrDefault(x => x.KayıtlıCSteamID == player.CSteamID);

            if (değer == null)
            {
                EffectManager.sendUIEffect(6493, 66, player.Player.channel.owner.transportConnection, true);
                EffectManager.sendUIEffectVisibility(66, player.Player.channel.owner.transportConnection, true, "KarakterGlobal", true);
                EffectManager.sendUIEffectText(66, player.Player.channel.owner.transportConnection, true, "ServerName", $"{Class1.Instance.Configuration.Instance.ServerName} <color=#FF8A00>Roleplay");
                player.Player.enablePluginWidgetFlag(EPluginWidgetFlags.Modal);
                Class1.Instance.KayıtOl.Add(new KayıtOlan { KayıtOlacakCSteamID = player.CSteamID });

                return;
            }
            EffectManager.sendUIEffect(6493, 66, player.Player.channel.owner.transportConnection, true);
            EffectManager.sendUIEffectVisibility(66, player.Player.channel.owner.transportConnection, true, "Kimlik-Ads", true);
            EffectManager.sendUIEffectText(66, player.Player.channel.owner.transportConnection, true, "KimlikAds-Name", $"{değer.KayıtlıAd} {değer.KayıtlıSoyad}");

        }
    }
}
