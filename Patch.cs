using Exiled.Loader.Features;
using HarmonyLib;
using PluginAPI.Core;
using System.Linq;
using Unity.Mathematics;

namespace IconSelectorMeow
{

    [HarmonyPatch(typeof(LoaderMessages), nameof(LoaderMessages.GetMessage))]
    internal class IconSelectorMeowPatch
    {
        private static bool Prefix(ref string __result)
        {
            bool useOriginal = APlugin.Instance.Config.UseOriginalIcons;
            bool useCustom = APlugin.Instance.Config.UseCustomIcons;

            if (useOriginal && !useCustom)
            {
                __result = IconManager.GetOriginalIcon();
            }
            else if (!useOriginal && useCustom)
            {
                __result = IconManager.GetCustomIcon();
            }
            else if (useOriginal && useCustom)
            {
                __result = new Random().NextFloat(0, 100) <= APlugin.Instance.Config.CustomIconChance ? IconManager.GetCustomIcon() : IconManager.GetOriginalIcon();
            }
            else
            {
                Log.Error("You must enable at least one icon type in config.");
                return true;
            }

            return false;
        }
    }

    internal static class IconManager
    {
        public static string GetOriginalIcon()
        {
            OriginalIconTypes type = OriginalIconTypes.Default;

            float total = APlugin.Instance.Config.Dictionary.Values.Sum();
            float random = (float)new System.Random().NextDouble();
            float current = 0.0f;

            Log.Info("Random: " + random + " Total: " + total);

            foreach (var item in APlugin.Instance.Config.Dictionary)
            {
                current += item.Value / total;
                Log.Info(current + " " + item.Value / total);

                if (random <= current)
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
            if (APlugin.Instance.Config.customIcon.Count == 0)
                Log.Error("Custom icon list is empty in config.");

            return APlugin.Instance.Config.customIcon[new Random().NextInt(0, APlugin.Instance.Config.customIcon.Count)];
        }
    }

}
