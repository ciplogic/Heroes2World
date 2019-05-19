using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHeroes2.SystemNs
{
    class H2Settings
    {
        public static H2Settings Instance { get; } = new H2Settings();

        public static H2Settings Get() => Instance;
    }
}
