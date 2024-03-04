using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsTranslator
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }

        public bool Debug { get; set; }

        public string FromLanguage { get; set; } = "en";

        public string ToLanguage { get; set; } = "ru";
    }
}
