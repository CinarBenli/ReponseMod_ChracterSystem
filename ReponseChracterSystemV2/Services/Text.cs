using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReponseChracterSystemV2.Services
{
    internal class Text
    {
        internal static void text(Player player, string buttonName, string text)
        {
            UnturnedPlayer pl = UnturnedPlayer.FromPlayer(player);
            var c = Class1.Instance.Configuration.Instance;
            var değer = Class1.Instance.KayıtOl.FirstOrDefault(e => e.KayıtOlacakCSteamID == pl.CSteamID);

            switch (buttonName)
            {
                case "Ad":

                    if (text.Length > c.NameLength)
                    {
                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "kimlikuyarı", $"<color=red><B>This Name Is Too Long!");
                    }
                    else
                    {
                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "kimlikuyarı", " ");
                        değer.KayıtOlacakAd = text;
                    }

                    break;
                case "Soyad":
                    if (text.Length > c.SurnameLength)
                    {
                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "kimlikuyarı", $"<color=red><B>This Surname Is Too Long!");
                    }
                    else
                    {
                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "kimlikuyarı", " ");
                        değer.KayıtOlacakSoyad = text;
                    }

                    break;
                case "Yaş":
                    var YaşParse = int.Parse(text);
                    if (YaşParse > c.AgeMax)
                    {
                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "kimlikuyarı", $"<color=red><B>You Can't Be That Big!");
                    }
                    else
                    {
                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "kimlikuyarı", " ");
                        değer.KayıtOlacakYaş = YaşParse;
                    }
                    break;
                case "Kilo":
                    var KiloParse = int.Parse(text);
                    if (KiloParse > c.WeightMax)
                    {
                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "kimlikuyarı", $"<color=red><B>You Can't Be That Overweight!");
                    }
                    else
                    {
                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "kimlikuyarı", " ");
                        değer.KayıtOlacakKilo = KiloParse;
                    }
                    break;
                case "Boy":
                    var BoyParse = int.Parse(text);
                    if (BoyParse > c.HeightMax)
                    {
                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "kimlikuyarı", $"<color=red><B>You Can not Have This Paint [110-{c.HeightMax}] There Should Be Decoupage]");
                    }
                    else if (BoyParse < 110)
                    {
                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "kimlikuyarı", $"<color=red><B>You Can not Have This Paint [110-{c.HeightMax}] There Should Be Decoupage]");
                    }
                    else
                    {
                        EffectManager.sendUIEffectText(66, pl.CSteamID, true, "kimlikuyarı", " ");
                        değer.KayıtOlacakBoy = BoyParse;
                    }
                    break;
            }
        }
    }
}
