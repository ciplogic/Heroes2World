using System;

namespace NHeroes2.GameNs
{
    [Flags]
    public enum GameOverCondition
    {
        COND_NONE = 0x0000,

        WINS_ALL = 0x0001,
        WINS_TOWN = 0x0002,
        WINS_HERO = 0x0004,
        WINS_ARTIFACT = 0x0008,
        WINS_SIDE = 0x0010,
        WINS_GOLD = 0x0020,
        WINS = WINS_ALL | WINS_TOWN | WINS_HERO | WINS_ARTIFACT | WINS_SIDE | WINS_GOLD,

        LOSS_ALL = 0x0100,
        LOSS_TOWN = 0x0200,
        LOSS_HERO = 0x0400,
        LOSS_TIME = 0x0800,
        LOSS_STARTHERO = 0x1000,
        LOSS = LOSS_ALL | LOSS_TOWN | LOSS_HERO | LOSS_TIME | LOSS_STARTHERO
    }
}