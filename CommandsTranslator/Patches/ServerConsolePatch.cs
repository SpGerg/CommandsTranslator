using Exiled.API.Features;
using HarmonyLib;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine.Windows;

namespace PluginsTranslator.Patches
{
    [HarmonyPatch(typeof(GameConsoleTransmission), nameof(GameConsoleTransmission.SendToClient), typeof(string), typeof(string))]
    public class ServerConsolePatch
    {
        private static void Prefix(ref string text, string color)
        {
            text = Requester.Request(text, Plugin.Singleton.Config.ToLanguage, Plugin.Singleton.Config.FromLanguage);
        }
    }
}
