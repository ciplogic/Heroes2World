using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHeroes2.Kingdom
{
    enum H2Color
    {
    NONE = 0x00,
    BLUE = 0x01,
    GREEN = 0x02,
    RED = 0x04,
    YELLOW = 0x08,
    ORANGE = 0x10,
    PURPLE = 0x20,
    UNUSED = 0x80,
    ALL = BLUE | GREEN | RED | YELLOW | ORANGE | PURPLE
    };
}
