using Exiled.API.Interfaces;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconSelectorMeow
{
    public enum OriginalIconTypes
    {
        Default,
        EasterEgg,
        Christmas,
        Halloween
    }

    public sealed class Config : IConfig
    {
        [Description("Whether the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Chance to use custom icon, select from 0 - 100. 0 means original icon only, 100 means custom icon only.")]
        public float CustomIconChance { get; set; } = 20.0f;

        [Description("If use original icons, then chance for each icons.")]
        public Dictionary<OriginalIconTypes, float> Dictionary { get; set; } = new Dictionary<OriginalIconTypes, float>
        {
            { OriginalIconTypes.Default, 25.0f },
            { OriginalIconTypes.EasterEgg, 25.0f },
            { OriginalIconTypes.Christmas, 25.0f },
            { OriginalIconTypes.Halloween, 25.0f }
        };

        [Description("You can get the text from website like https://www.patorjk.com/software/taag. Please add \\n for line feed.")]
        public List<string> customIcon { get; set; } = new List<string>
        {
            "\n __   __                         ___                        \r\n" +
            " \\ \\ / /   ___    _   _   _ __  |_ _|   ___    ___    _ __  \r\n" +
            "  \\ V /   / _ \\  | | | | | '__|  | |   / __|  / _ \\  | '_ \\ \r\n" +
            "   | |   | (_) | | |_| | | |     | |  | (__  | (_) | | | | |\r\n" +
            "   |_|    \\___/   \\__,_| |_|    |___|  \\___|  \\___/  |_| |_|\r\n" +
            "                                                            "
            ,
            "\n  __  __                           \r\n" +
            " |  \\/  |   ___    ___   __      __\r\n" +
            " | |\\/| |  / _ \\  / _ \\  \\ \\ /\\ / /\r\n" +
            " | |  | | |  __/ | (_) |  \\ V  V / \r\n" +
            " |_|  |_|  \\___|  \\___/    \\_/\\_/  \r\n" +
            "                                   ",
        };
    }
}
