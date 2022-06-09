using ReponseChracterSystemV2.Model;
using ReponseChracterSystemV2.Services;
using Rocket.API;
using Rocket.Core.Commands;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Permissions;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReponseChracterSystemV2
{
    public class Class1 : RocketPlugin<Config>
    {
        public List<Model.KayıtOlan> KayıtOl = new List<Model.KayıtOlan>();

        public static Class1 Instance { get; private set; }

        protected override void Load()
        {
            Instance = this;
            U.Events.OnPlayerConnected += Join.join;
            EffectManager.onEffectButtonClicked += Button.button;
            EffectManager.onEffectTextCommitted += Text.text;
            UnturnedPermissions.OnJoinRequested += Request.request;
            UnturnedPlayerEvents.OnPlayerUpdateGesture += Gesture.gesture;
            PlayerQuests.onGroupChanged += Test;
            base.Load();
        }

        private void Test(PlayerQuests sender, CSteamID oldGroupID, EPlayerGroupRank oldGroupRank, CSteamID newGroupID, EPlayerGroupRank newGroupRank)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<WaitForSeconds> Kimlik(UnturnedPlayer Kimlik, CSteamID Bakan)
        {
            EffectManager.sendUIEffectVisibility(66, Bakan, true, "KimlikGlobal", true);
            var değer = Configuration.Instance.Kayıtlı.FirstOrDefault(e => e.KayıtlıCSteamID == Kimlik.CSteamID);
            EffectManager.sendUIEffectImageURL(66, Bakan, true, "Image", Kimlik.SteamProfile.AvatarIcon.ToString());
            EffectManager.sendUIEffectText(66, Bakan, true, "Kimlik-Name", değer.KayıtlıAd);
            EffectManager.sendUIEffectText(66, Bakan, true, "Kimlik-Surname", değer.KayıtlıSoyad);
            EffectManager.sendUIEffectText(66, Bakan, true, "Kimlik-Age", değer.KayıtlıYaş.ToString());
            EffectManager.sendUIEffectText(66, Bakan, true, "Kimlik-Width", değer.KayıtlıKilo.ToString());
            EffectManager.sendUIEffectText(66, Bakan, true, "Kimlik-Height", değer.KayıtlıBoy.ToString());
            yield return new WaitForSeconds(3);
            EffectManager.sendUIEffectVisibility(66, Bakan, true, "KimlikGlobal", false);



        }
        [RocketCommand("go", "You Teleport to a Player", "/go <Id>", AllowedCaller.Both)]
        [RocketCommandPermission("r.admin")]
        public void saa(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = caller as UnturnedPlayer;

            if (command.Length <= 0)
            {
                ChatManager.serverSendMessage($"<color=orange>Attention|</color> You Must Enter Serial No!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);

            }
            else
            {
                var değers = Convert.ToUInt32(command[0]);
                var değer = Configuration.Instance.Kayıtlı.FirstOrDefault(x => x.KayıtlıSıraNo == değers);

                if (değer == null)
                {
                    ChatManager.serverSendMessage($"<color=orange>Attention|</color> No Registered Users Have been Found for This Serial Number!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                }
                else
                {
                    UnturnedPlayer target = UnturnedPlayer.FromCSteamID(değer.KayıtlıCSteamID);
                    if (target != null)
                    {
                        player.Teleport(target);
                        ChatManager.serverSendMessage($"<color=green>Go|</color> You Successfully Teleported to the User Named {target.CharacterName}!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                    }
                    else
                    {
                        ChatManager.serverSendMessage($"<color=orange>Dikkat|</color> Kullanıcı Aktif Değil!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                    }
                }


            }

        }
        [RocketCommand("shoot", "You Throw a Player Off the Server", "/shoot <Id>", AllowedCaller.Both)]
        [RocketCommandPermission("r.admin")]
        public void saaa(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = caller as UnturnedPlayer;

            if (command.Length <= 0)
            {
                ChatManager.serverSendMessage($"<color=orange>Attention|</color> You Must Enter Serial No!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);

            }
            else
            {
                var değers = Convert.ToUInt32(command[0]);
                var değer = Configuration.Instance.Kayıtlı.FirstOrDefault(x => x.KayıtlıSıraNo == değers);

                if (değer == null)
                {
                    ChatManager.serverSendMessage($"<color=orange>Attention|</color> No Registered Users Have been Found for This Serial Number!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                }
                else
                {
                    UnturnedPlayer target = UnturnedPlayer.FromCSteamID(değer.KayıtlıCSteamID);
                    if (target != null)
                    {
                        ChatManager.serverSendMessage($"<color=green>Shoot|</color> You Have Successfully Ejected the User Named {target.CharacterName} From the Server!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                        target.Kick($"You were Kicked Out By an Official Named {player.CharacterName}.");
                    }
                    else
                    {
                        ChatManager.serverSendMessage($"<color=orange>Attention|</color> The User is Inactive!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                    }
                }
            }

        }
        [RocketCommand("block", "You Block a Player From the Server.", "/block <Id>", AllowedCaller.Both)]
        [RocketCommandPermission("r.adminplus")]
        public void saaaa(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = caller as UnturnedPlayer;

            if (command.Length <= 0)
            {
                ChatManager.serverSendMessage($"<color=orange>Attention|</color> You Must Enter Serial No!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);

            }
            else
            {
                var değers = Convert.ToUInt32(command[0]);
                var değer = Configuration.Instance.Kayıtlı.FirstOrDefault(x => x.KayıtlıSıraNo == değers);

                if (değer == null)
                {
                    ChatManager.serverSendMessage($"<color=orange>Attention|</color> No Registered Users Have been Found for This Serial Number!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                }
                else
                {
                    UnturnedPlayer target = UnturnedPlayer.FromCSteamID(değer.KayıtlıCSteamID);
                    if (target != null)
                    {
                        target.Ban($"You have been Removed from the Server by an Official Named {player.CharacterName}.", 365000000);
                        ChatManager.serverSendMessage($"<color=green>Block|</color> You have Successfully Banned the User Named {target.CharacterName} From the Server!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                    }
                    else
                    {
                        ChatManager.serverSendMessage($"<color=orange>Attention|</color> The User is Inactive!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                    }
                }
            }

        }

        [RocketCommand("check", "You Attract a Player To Yourself.", "/check <Id>", AllowedCaller.Both)]
        [RocketCommandPermission("r.admin")]
        public void saaaaa(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = caller as UnturnedPlayer;

            if (command.Length <= 0)
            {
                ChatManager.serverSendMessage($"<color=orange>Attention|</color> You Must Enter Serial No!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);

            }
            else
            {
                var değers = Convert.ToUInt32(command[0]);
                var değer = Configuration.Instance.Kayıtlı.FirstOrDefault(x => x.KayıtlıSıraNo == değers);

                if (değer == null)
                {
                    ChatManager.serverSendMessage($"<color=orange>Attention|</color> No Registered Users Have been Found for This Serial Number!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                }
                else
                {
                    UnturnedPlayer target = UnturnedPlayer.FromCSteamID(değer.KayıtlıCSteamID);
                    if (target != null)
                    {
                        target.Teleport(player);
                        ChatManager.serverSendMessage($"<color=green>Check|</color> You Have Successfully Attracted the User Named {target.CharacterName} to Yourself!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                    }
                    else
                    {
                        ChatManager.serverSendMessage($"<color=orange>Attention|</color> The User is Inactive!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                    }
                }
            }

        }

        [RocketCommand("ck", "You Delete a Player's Character.", "/ck <Id>", AllowedCaller.Both)]
        [RocketCommandPermission("r.adminplus")]
        public void saaaaaa(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = caller as UnturnedPlayer;

            if (command.Length <= 0)
            {
                ChatManager.serverSendMessage($"<color=orange>Attention|</color> You Must Enter Serial No!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);

            }
            else
            {
                var değers = Convert.ToUInt32(command[0]);
                var değer = Configuration.Instance.Kayıtlı.FirstOrDefault(x => x.KayıtlıSıraNo == değers);

                if (değer == null)
                {
                    ChatManager.serverSendMessage($"<color=orange>Attention|</color> No Registered Users Have been Found for This Serial Number!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                }
                else
                {
                    UnturnedPlayer target = UnturnedPlayer.FromCSteamID(değer.KayıtlıCSteamID);
                    ChatManager.serverSendMessage($"<color=green>CK|</color> Successfully CK Was Thrown to the Player!", Color.white, player.SteamPlayer(), player.SteamPlayer(), (EChatMode)4, Configuration.Instance.Logo, true);
                    target.Kick("You're Off the Record!");
                    Configuration.Instance.Kayıtlı.Remove(değer);

                }
            }
        }
        
    
    }
}
