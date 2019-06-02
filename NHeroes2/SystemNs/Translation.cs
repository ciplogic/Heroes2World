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
