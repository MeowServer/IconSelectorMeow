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
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
    using System.ComponentModel;
    using Unity.Mathematics;

    public class APlugin
    {
        [PluginConfig] public Config Config;

        internal static APlugin Instance { get; private set; }
        private Harmony harmony;

        [PluginEntryPoint("AnIconSelectorMeow", "1.0.1", "Select the Exiled icon you want to show", "MeowServer")]
        [PluginPriority(byte.MinValue)]
        private void Enabled()
        {
            Log.Info("IconSelectorMeow had been loaded");

            if (!Config.IsEnabled)
            {
                return;
            }

            Instance = this;

            harmony = new Harmony("IconSelectorMeow 1.0.1");
            harmony.PatchAll();
        }
    }

    
}
