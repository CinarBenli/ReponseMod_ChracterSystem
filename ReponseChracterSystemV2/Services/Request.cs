using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReponseChracterSystemV2.Services
{
    internal class Request
    {
        internal static void request(CSteamID player, ref ESteamRejection? rejectionReason)
        {
            SteamPending steam = Provider.pending.FirstOrDefault((SteamPending p) => p.playerID.steamID.m_SteamID == player.m_SteamID);
            var değer = Class1.Instance.Configuration.Instance.Kayıtlı.FirstOrDefault(e => e.KayıtlıCSteamID == player);
            if (değer == null)
            {
                steam.playerID.characterName = $"Unregistered";
                steam.playerID.nickName = $"Unregistered";
            }
            else
            {
                steam.playerID.characterName = $"{değer.KayıtlıAd} {değer.KayıtlıSoyad} | NO:{değer.KayıtlıSıraNo}";
                steam.playerID.nickName = $"{değer.KayıtlıAd} {değer.KayıtlıSoyad} | NO:{değer.KayıtlıSıraNo}";
            }
        }
    }
}
