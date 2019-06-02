using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHeroes2.MonsterNs;

namespace NHeroes2.ArmyNs
{
    class Army
    {
        
    }
    class Troop
    {
        public Monster _monster;
        public int count = 0;
        public bool IsValid()
        {
            return _monster.IsValid() && (count>0);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
