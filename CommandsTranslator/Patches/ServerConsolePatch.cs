using HarmonyLib;

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
