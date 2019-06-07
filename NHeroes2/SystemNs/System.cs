using System;
using System.Collections.Generic;
using System.Drawing;
using NHeroes2.Engine;
using NHeroes2.GameNs;
using NHeroes2.MapsNs;

namespace NHeroes2.SystemNs
{
    public class H2Settings
    {
        public static H2Settings Instance { get; } = new H2Settings();

        public static H2Settings Get() => Instance;
        H2FileInfo current_maps_file = new H2FileInfo();
        
        
        BitModes opt_global = new BitModes();
        BitModes opt_game= new BitModes();
        BitModes opt_battle= new BitModes();
        BitModes opt_world= new BitModes();
        BitModes opt_addons= new BitModes();
        
        
        int debug;
        Size video_mode;
        bool fullScreen;
        int game_difficulty;

        string path_program;
        string data_params;
        ListDirs maps_params = new ListDirs();

        string font_normal;
        string font_small;
        string force_lang;
        string maps_charset;
        int size_normal;
        int size_small;

        bool _isQuickCombat;
        bool _isUiHeroesBar;


        
        int sound_volume;
        int music_volume;
        int heroes_speed;
        int ai_speed;
        int scroll_speed;
        int battle_speed;
        int blit_speed;

        int game_type;
        int preferably_count_players;

        string video_driver;

        int port;
        uint memory_limit;

        H2Point pos_radr;
        H2Point pos_bttn;
        H2Point pos_icon;
        H2Point pos_stat;

        Players players = new Players();
        
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
                default:
                    break;
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
    }
}