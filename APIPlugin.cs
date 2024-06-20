using PluginAPI.Core.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;
using PluginAPI.Core;

namespace IconSelectorMeow
{
    // * Version History
    // * V1.0.0
    // * - Initial release
    // * V1.1.0
    // * - Add Exiled support
    // * V1.1.1
    // * - Fix the bug that make UseCustomIcon and UseOriginalIcon not working
    // * - Fix the bug that OnEnabled config does not works in Exiled
    // * - Add "YourIcon" into default config and add a link to icon making website
    // * V1.1.2
    // * - Fix the bug that randomizer does not work properly
    public class APIPlugin
    {
        [PluginConfig] public Config Config;

        [PluginEntryPoint("AnIconSelectorMeow", "1.1.2", "Select the Exiled icon you want to show", "MeowServer")]
        [PluginPriority(byte.MinValue)]
        private void Enabled()
        {
            if (Config.IsEnabled == false)
                return;

            Log.Info("IconSelectorMeow had been loaded in NWAPI");

            Plugin.config = Config;
            PatchManager.TryPatch();
        }
    }

    public class ExiledPlugin : Exiled.API.Features.Plugin<Config>
    {
        public override string Name => "IconSelectorMeow";

        public override string Author => "MeowServer";

        public override Version Version => new Version(1,1,2);

        public ExiledPlugin()
        {
            if (Config.IsEnabled == false)
                return;

            Log.Info("IconSelectorMeow had been loaded in Exiled");
            Plugin.config = Config;
            PatchManager.TryPatch();
        }
    }

    public static class Plugin
    {
        public static Config config;
    }

    public static class PatchManager
    {
        private static Harmony harmony;

        private static bool Patched = false;

        public static void TryPatch()
        {
            if(Patched)
            {
                return;
            }

            Patched = true;
            harmony = new Harmony("IconSelectorMeow 1.1.2");
            harmony.PatchAll();
        }

    }
}
