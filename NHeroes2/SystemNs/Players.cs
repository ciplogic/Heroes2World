using System;
using NHeroes2.KingdomNs;

namespace NHeroes2.SystemNs
{
    class Players
    {
        static Player[] _players = new Player[H2Consts.KINGDOMMAX + 1] ;


    public static int HumanColors()
        {
            throw new NotImplementedException();
        }

        public static bool GetPlayerInGame(int color)
        {
            var  player = Get(color);
            return player != null && player.isPlay();
        }

        private static Player Get(int color)
        {
            return _players[H2Color.GetIndex(color)];
        }
    }
}
