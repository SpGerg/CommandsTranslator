using Exiled.API.Features;
using HarmonyLib;

namespace PluginsTranslator
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton { get; private set; }

        public override void OnEnabled()
        {
            Singleton = this;

            var harmony = new Harmony("spgerg");
            harmony.PatchAll();

            base.OnEnabled();
        }
    }
}
