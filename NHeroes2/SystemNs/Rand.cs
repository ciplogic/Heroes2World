using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHeroes2.SystemNs
{
    class Rand
    {
        static Random rnd = new Random();
        public static T Get<T>(IList<T> items)
        {
            int r = rnd.Next(items.Count);
            return items[r];
        }
    }
}
