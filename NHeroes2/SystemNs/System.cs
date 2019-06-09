using System;
using System.Drawing;
using NHeroes2.Engine;
using NHeroes2.GameNs;
using NHeroes2.MapsNs;

namespace NHeroes2.SystemNs
{
    public class H2Settings
    {
        private readonly H2FileInfo current_maps_file = new H2FileInfo();
        private readonly BitModes opt_addons = new BitModes();
        private readonly BitModes opt_battle = new BitModes();
        private readonly BitModes opt_game = new BitModes();
        private readonly BitModes opt_world = new BitModes();

        private readonly Players players = new Players();
        private bool _isQuickCombat;
        private bool _isUiHeroesBar;
        private int ai_speed;
        private int battle_speed;
        private int blit_speed;
        private string data_params;


        private int debug;

        private string font_normal;
        private string font_small;
        private string force_lang;
        private bool fullScreen;
        private int game_difficulty;

        private int game_type;
        private int heroes_speed;
        private string maps_charset;
        private ListDirs maps_params = new ListDirs();
        private uint memory_limit;
        private int music_volume;


        private BitModes opt_global = new BitModes();

        private string path_program;

        private int port;
        private H2Point pos_bttn;
        private H2Point pos_icon;

        private H2Point pos_radr;
        private H2Point pos_stat;
        private int preferably_count_players;
        private int scroll_speed;
        private int size_normal;
        private int size_small;


        private int sound_volume;

        private string video_driver;
        private Size video_mode;
        public static H2Settings Instance { get; } = new H2Settings();

        public static H2Settings Get()
        {
            return Instance;
        }

        public bool PriceLoyaltyVersion()
        {
            return false;
        }

        public GameOverCondition ConditionWins()
        {
            return current_maps_file.ConditionWins();
        }

        public static bool IS_DEVEL()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        public H2Point WinsMapsPositionObject()
        {
            throw new NotImplementedException();
        }

        public GameOverCondition ConditionLoss()
        {
            return current_maps_file.ConditionLoss();
        }

        public H2Point LossMapsPositionObject()
        {
            throw new NotImplementedException();
        }

        public bool ExtModes(uint f)
        {
            uint mask = 0x0FFFFFFF;
            switch (f >> 28)
            {
                case 0x01:
                    return opt_game.Modes(f & mask);
                case 0x02:
                    return opt_world.Modes(f & mask);
                case 0x03:
                    return opt_addons.Modes(f & mask);
                case 0x04:
                    return opt_battle.Modes(f & mask);
            }

            return false;
        }

        public bool ExtWorldStartHeroLossCond4Humans()
        {
            return ExtModes((uint) SettingsFlags.WORLD_STARTHERO_LOSSCOND4HUMANS);
        }

        public bool GameStartWithHeroes()
        {
            throw new NotImplementedException();
        }

        public Players GetPlayers()
        {
            return players;
        }

        public int CurrentColor()
        {
            return players.current_color;
        }
    }
}