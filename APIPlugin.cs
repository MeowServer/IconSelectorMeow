using Exiled.Loader;
using PluginAPI.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconSelectorMeow
{
    using Exiled.Loader.Features;
    using HarmonyLib;
    using Org.BouncyCastle.Asn1.Mozilla;
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
    using System.ComponentModel;
    using Unity.Mathematics;


    // * Version History
    // * V1.0.0
    // * - Initial release
    // * V1.1.0
    // * - Add Exiled support
    // * V1.1.1
    // * - Fix the bug that make UseCustomIcon and UseOriginalIcon not working
    // * - Fix the bug that OnEnabled config does not works in Exiled
    // * - Add "YourIcon" into default config and add a link to icon making website
    public class APIPlugin
    {
        [PluginConfig] public Config Config;

        [PluginEntryPoint("AnIconSelectorMeow", "1.1.1", "Select the Exiled icon you want to show", "MeowServer")]
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

        public override Version Version => new Version(1,1,1);

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
            harmony = new Harmony("IconSelectorMeow 1.0.1");
            harmony.PatchAll();
        }

    }
}
