using System;
using System.Collections.Generic;

namespace NHeroes2.SystemNs
{
    internal class Rand
    {
        private static readonly Random rnd = new Random();

        public static T Get<T>(IList<T> items)
        {
            var r = rnd.Next(items.Count);
            return items[r];
        }
    }
}