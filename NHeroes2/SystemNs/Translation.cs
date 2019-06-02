using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHeroes2.SystemNs
{
    static class Translation
    {
        public static string _(string text)
            => text;

        public static void StringReplace(ref string text, string from, string to)
        {
            text = text.Replace(from, to);
        }
    }
}
