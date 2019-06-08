namespace NHeroes2.SystemNs
{
    internal static class Translation
    {
        public static string _(string text)
        {
            return text;
        }

        public static void StringReplace(ref string text, string from, string to)
        {
            text = text.Replace(from, to);
        }
    }
}