using Exiled.Loader.Features;
using HarmonyLib;
using PluginAPI.Core;
using System;
using System.Linq;

namespace IconSelectorMeow
{

    [HarmonyPatch(typeof(LoaderMessages), nameof(LoaderMessages.GetMessage))]
    internal class IconSelectorMeowPatch
    {
        private static bool Prefix(ref string __result)
        {
            try
            {
                double chance = Plugin.config.CustomIconChance / 100.0;
                bool useCustomIcon = IconManager.randomizer.NextDouble() < chance;
                __result = useCustomIcon ? IconManager.GetCustomIcon() : IconManager.GetOriginalIcon();
            }
            catch(Exception e)
            {
                Log.Error("Error in IconSelectorMeowPatch: " + e.Message);
                return true;
            }

            return false;
        }
    }

    internal static class IconManager
    {
        public static readonly Random randomizer = new Random(DateTime.Now.GetHashCode());

        public static string GetOriginalIcon()
        {
            OriginalIconTypes type = OriginalIconTypes.Default;

            float total = Plugin.config.Dictionary.Values.Sum();
            float randomNum = (float)randomizer.NextDouble();
            float current = 0.0f;

            foreach (var item in Plugin.config.Dictionary)
            {
                current += item.Value / total;

                if (randomNum <= current)
                {
                    type = item.Key;
                    break;
                }
            }

            switch (type)
            {
                case OriginalIconTypes.Default:
                    return LoaderMessages.Default;
                case OriginalIconTypes.EasterEgg:
                    return LoaderMessages.EasterEgg;
                case OriginalIconTypes.Christmas:
                    return LoaderMessages.Christmas;
                case OriginalIconTypes.Halloween:
                    return LoaderMessages.Halloween;
            }

            Log.Error("Type cannot be found in GetOriginalIcon. Type: " + type);
            return string.Empty;
        }

        public static string GetCustomIcon()
        {
            if (Plugin.config.customIcon.Count == 0)
                Log.Error("Custom icon list is empty in config.");

            return Plugin.config.customIcon[randomizer.Next(0, Plugin.config.customIcon.Count)];
        }
    }

}
