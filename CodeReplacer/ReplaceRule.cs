namespace CodeReplacer
{
    internal class ReplaceRule
    {
        public string From;
        public string To;

        public ReplaceRule(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}