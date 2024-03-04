using Exiled.API.Features;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
