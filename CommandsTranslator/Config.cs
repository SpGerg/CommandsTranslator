using Exiled.API.Interfaces;
using System.ComponentModel;

namespace PluginsTranslator
{
    public class Config : IConfig
    {
        [Description("Is enabled or not")]
        public bool IsEnabled { get; set; }

        [Description("Is debug or not")]
        public bool Debug { get; set; }

        [Description("Original response language")]
        public string FromLanguage { get; set; } = "en";

        [Description("Translate language")]
        public string ToLanguage { get; set; } = "ru";
    }
}
