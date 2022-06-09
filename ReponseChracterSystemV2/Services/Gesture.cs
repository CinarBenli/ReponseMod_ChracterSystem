using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReponseChracterSystemV2.Services
{
    internal class Gesture
    {
        internal static void gesture(UnturnedPlayer player, UnturnedPlayerEvents.PlayerGesture gesture)
        {
            if (gesture != UnturnedPlayerEvents.PlayerGesture.Point) return;   

            if (Physics.Raycast(player.Player.look.aim.position, player.Player.look.aim.forward, out RaycastHit hit, 10, RayMasks.PLAYER_INTERACT) && hit.transform.TryGetComponent(out Player pls))
            {
                UnturnedPlayer pl = UnturnedPlayer.FromPlayer(pls);
                if (pl == null) return;
                if (pl.Player.equipment.asset.id != Class1.Instance.Configuration.Instance.IdentityID) return;

                Class1.Instance.StartCoroutine(Class1.Instance.Kimlik(pl , player.CSteamID));
            }

        }
    }
}
