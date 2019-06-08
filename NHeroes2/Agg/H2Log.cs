using System;

namespace NHeroes2.Agg
{
    internal static class H2Log
    {
        public static void H2ERROR(string text)
        {
            Console.WriteLine("Error: " + text);
        }
    }
}