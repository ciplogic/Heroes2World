using System.Collections.Generic;
using NHeroes2.KingdomNs;

namespace NHeroes2.SystemNs
{
    public class Players
    {
        private static readonly Player[] _players = new Player[H2Consts.KINGDOMMAX + 1];
        private static int human_colors;

        private readonly List<Player> _items = new List<Player>();
        public int current_color;

        public static int HumanColors()
        {
            if (0 == human_colors)
                human_colors = H2Settings.Get().GetPlayers().GetColors((int) control_t.CONTROL_HUMAN, true);
            return human_colors;
        }

        private int GetColors(int control, bool strong)
        {
            var res = 0;

            foreach (var it in _items)
                if (control == 0xFF ||
                    strong && it.GetControl() == control ||
                    !strong && (it.GetControl() & control) != 0)
                    res |= it.GetColor();

            return res;
        }

        public static bool GetPlayerInGame(int color)
        {
            var player = Get(color);
            return player != null && player.isPlay();
        }

        private static Player Get(int color)
        {
            return _players[H2Color.GetIndex(color)];
        }
    }
}