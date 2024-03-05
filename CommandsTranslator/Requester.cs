using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace PluginsTranslator
{
    public static class Requester
    {
        public const int MaxLengthToTranslate = 3900;

        public static string Request(string message, string to, string from)
        {
            if (message.Length > MaxLengthToTranslate)
            {
                var half = message.Substring(0, 3900);

                return Request(half, to, from) + Request(message.Substring(3900, message.Length), to, from);
            }

            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={from}&tl={to}&dt=t&q={message}";
            var webClient = new WebClient
            {
                Encoding = Encoding.UTF8
            };

            var result = webClient.DownloadString(url);

            var matches = Regex.Matches(result, "\"" + @"(.+?)" + "\"");

            result = string.Empty;

            for (var i = 0; i < matches.Count; i++)
            {
                var match = matches[i];

                //After translated message, we have original message. We didnt need and skip it.
                //...5521abb im dont know what is, but im dont wanna to show it because it can show my private info. 
                //en_ru_2023q1.md it is third thing from google
                if (i % 2 != 0 || match.Value.Contains("abb") || match.Value.Contains("md"))
                {
                    continue;
                }

                ////r and /n, can be on string end, substring cuz match value starting with '"' char,
                result += match.Value.Substring(1, match.Value.Length - 2).Replace("\\n", "\n").Replace("\\r", "\r");
            }

            return result;
        }
    }
}
