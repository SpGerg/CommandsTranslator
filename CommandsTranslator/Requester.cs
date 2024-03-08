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

                //banalnybanan comments editor
                //After the translated message comes the original one, we don’t need it, so we skip it.
                //...5521abb i don't know what that means, so we'll skip it.
                //en_ru_2023q1.md this is the third answer from Google
                if (i % 2 != 0 || match.Value.Contains("abb") || match.Value.Contains("md"))
                {
                    continue;
                }

                // /r and /n can be at the end of a line, they are not special characters, so we make them special characters.
                result += match.Value.Substring(1, match.Value.Length - 2).Replace("\\n", "\n").Replace("\\r", "\r");
            }

            return result;
        }
    }
}
