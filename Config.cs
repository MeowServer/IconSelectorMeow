using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IconSelectorMeow.IconManager;

namespace IconSelectorMeow
{
    public enum OriginalIconTypes
    {
        Default,
        EasterEgg,
        Christmas,
        Halloween
    }

    public sealed class Config
    {
        [Description("Whether the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether to use Exiled's embeded icons.")]
        public bool UseOriginalIcons { get; set; } = true;

        [Description("Whether to use custom icons.")]
        public bool UseCustomIcons { get; set; } = true;

        [Description("If use both icons, then chance to use custom one, select from 0 - 100")]
        public float CustomIconChance { get; set; } = 20.0f;

        [Description("If use original icons, then chance for each icons")]
        public Dictionary<OriginalIconTypes, float> Dictionary { get; set; } = new Dictionary<OriginalIconTypes, float>
        {
            { OriginalIconTypes.Default, 25.0f },
            { OriginalIconTypes.EasterEgg, 25.0f },
            { OriginalIconTypes.Christmas, 25.0f },
            { OriginalIconTypes.Halloween, 25.0f }
        };

        public List<string> customIcon { get; set; } = new List<string>
        {
            "\n  __  __                           \r\n" +
            " |  \\/  |   ___    ___   __      __\r\n" +
            " | |\\/| |  / _ \\  / _ \\  \\ \\ /\\ / /\r\n" +
            " | |  | | |  __/ | (_) |  \\ V  V / \r\n" +
            " |_|  |_|  \\___|  \\___/    \\_/\\_/  \r\n" +
            "                                   ",
        };
    }
}
