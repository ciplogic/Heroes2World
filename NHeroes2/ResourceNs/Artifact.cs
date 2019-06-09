using System;
using System.Collections.Generic;
using NHeroes2.Utilities;
using static NHeroes2.SystemNs.Translation;

namespace NHeroes2.ResourceNs
{
    internal class Artifact
    {
        private int ext;
        private readonly ArtifactKind id;

        public Artifact(int artifactKind)
        {
            id = (ArtifactKind) artifactKind;
        }

        private static List<artifactstats_t> artifacts => AllArtifacts.artifacts;

        public static Artifact FromMP2IndexSprite(uint addonIndex)
        {
            throw new NotImplementedException();
        }

        public static int Rand(ArtifactLevel lvl)
        {
            var v = new List<int>();

            // if possibly: make unique on map
            for (var art = ArtifactKind.ULTIMATE_BOOK; art < ArtifactKind.UNKNOWN; ++art)
                if ((lvl & new Artifact((int) art).Level()) != 0 &&
                    (artifacts[(int) art].bits & (int) ArtifactBits.ART_DISABLED) == 0 &&
                    (artifacts[(int) art].bits & (int) ArtifactBits.ART_RNDUSED) == 0)
                    v.Add((int) art);

            //
            if (v.empty())
                for (var art = ArtifactKind.ULTIMATE_BOOK; art < ArtifactKind.UNKNOWN; ++art)
                    if ((lvl & new Artifact((int) art).Level()) != 0 &&
                        (artifacts[(int) art].bits & (int) ArtifactBits.ART_DISABLED) == 0)
                        v.Add((int) art);

            var res = !v.empty() ? Engine.Rand.Get(v) : (int) ArtifactKind.UNKNOWN;
            artifacts[res].bits |= (byte) ArtifactBits.ART_RNDUSED;

            return res;
        }

        private ArtifactLevel Level()
        {
            switch (id)
            {
                case ArtifactKind.MEDAL_VALOR:
                case ArtifactKind.MEDAL_COURAGE:
                case ArtifactKind.MEDAL_HONOR:
                case ArtifactKind.MEDAL_DISTINCTION:
                case ArtifactKind.THUNDER_MACE:
                case ArtifactKind.ARMORED_GAUNTLETS:
                case ArtifactKind.DEFENDER_HELM:
                case ArtifactKind.GIANT_FLAIL:
                case ArtifactKind.RABBIT_FOOT:
                case ArtifactKind.GOLDEN_HORSESHOE:
                case ArtifactKind.GAMBLER_LUCKY_COIN:
                case ArtifactKind.FOUR_LEAF_CLOVER:
                case ArtifactKind.ENCHANTED_HOURGLASS:
                case ArtifactKind.ICE_CLOAK:
                case ArtifactKind.FIRE_CLOAK:
                case ArtifactKind.LIGHTNING_HELM:
                case ArtifactKind.SNAKE_RING:
                case ArtifactKind.HOLY_PENDANT:
                case ArtifactKind.PENDANT_FREE_WILL:
                case ArtifactKind.PENDANT_LIFE:
                case ArtifactKind.PENDANT_DEATH:
                case ArtifactKind.GOLDEN_BOW:
                case ArtifactKind.TELESCOPE:
                case ArtifactKind.SERENITY_PENDANT:
                case ArtifactKind.STATESMAN_QUILL:
                case ArtifactKind.KINETIC_PENDANT:
                case ArtifactKind.SEEING_EYE_PENDANT:
                    return ArtifactLevel.ART_LEVEL1;

                case ArtifactKind.CASTER_BRACELET:
                case ArtifactKind.MAGE_RING:
                case ArtifactKind.STEALTH_SHIELD:
                case ArtifactKind.POWER_AXE:
                case ArtifactKind.MINOR_SCROLL:
                case ArtifactKind.ENDLESS_PURSE_GOLD:
                case ArtifactKind.SAILORS_ASTROLABE_MOBILITY:
                case ArtifactKind.ENDLESS_CORD_WOOD:
                case ArtifactKind.ENDLESS_CART_ORE:
                case ArtifactKind.SPIKED_HELM:
                case ArtifactKind.WHITE_PEARL:
                case ArtifactKind.EVIL_EYE:
                case ArtifactKind.GOLD_WATCH:
                case ArtifactKind.ANKH:
                case ArtifactKind.BOOK_ELEMENTS:
                case ArtifactKind.ELEMENTAL_RING:
                case ArtifactKind.SKULLCAP:
                case ArtifactKind.EVERCOLD_ICICLE:
                case ArtifactKind.POWER_RING:
                case ArtifactKind.AMMO_CART:
                case ArtifactKind.EVERHOT_LAVA_ROCK:
                    return ArtifactLevel.ART_LEVEL2;

                case ArtifactKind.ARCANE_NECKLACE:
                case ArtifactKind.WITCHES_BROACH:
                case ArtifactKind.BALLISTA:
                case ArtifactKind.DRAGON_SWORD:
                case ArtifactKind.DIVINE_BREASTPLATE:
                case ArtifactKind.MAJOR_SCROLL:
                case ArtifactKind.SUPERIOR_SCROLL:
                case ArtifactKind.FOREMOST_SCROLL:
                case ArtifactKind.ENDLESS_SACK_GOLD:
                case ArtifactKind.ENDLESS_BAG_GOLD:
                case ArtifactKind.NOMAD_BOOTS_MOBILITY:
                case ArtifactKind.TRAVELER_BOOTS_MOBILITY:
                case ArtifactKind.TRUE_COMPASS_MOBILITY:
                case ArtifactKind.ENDLESS_POUCH_SULFUR:
                case ArtifactKind.ENDLESS_POUCH_GEMS:
                case ArtifactKind.ENDLESS_POUCH_CRYSTAL:
                case ArtifactKind.ENDLESS_VIAL_MERCURY:
                case ArtifactKind.SPIKED_SHIELD:
                case ArtifactKind.BLACK_PEARL:
                case ArtifactKind.LIGHTNING_ROD:
                case ArtifactKind.WAND_NEGATION:
                case ArtifactKind.WIZARD_HAT:
                    return ArtifactLevel.ART_LEVEL3;

                case ArtifactKind.ULTIMATE_BOOK:
                case ArtifactKind.ULTIMATE_SWORD:
                case ArtifactKind.ULTIMATE_CLOAK:
                case ArtifactKind.ULTIMATE_WAND:
                case ArtifactKind.ULTIMATE_SHIELD:
                case ArtifactKind.ULTIMATE_STAFF:
                case ArtifactKind.ULTIMATE_CROWN:
                case ArtifactKind.GOLDEN_GOOSE:
                    return ArtifactLevel.ART_ULTIMATE;

                // no random
                case ArtifactKind.MAGIC_BOOK:
                case ArtifactKind.FIZBIN_MISFORTUNE:
                case ArtifactKind.TAX_LIEN:
                case ArtifactKind.HIDEOUS_MASK:
                    return ArtifactLevel.ART_NORANDOM;

                // price loyalty
                case ArtifactKind.SPELL_SCROLL:
                case ArtifactKind.ARM_MARTYR:
                case ArtifactKind.BREASTPLATE_ANDURAN:
                case ArtifactKind.BROACH_SHIELDING:
                case ArtifactKind.BATTLE_GARB:
                case ArtifactKind.CRYSTAL_BALL:
                case ArtifactKind.HELMET_ANDURAN:
                case ArtifactKind.HOLY_HAMMER:
                case ArtifactKind.LEGENDARY_SCEPTER:
                case ArtifactKind.MASTHEAD:
                case ArtifactKind.SPHERE_NEGATION:
                case ArtifactKind.STAFF_WIZARDRY:
                case ArtifactKind.SWORD_BREAKER:
                case ArtifactKind.SWORD_ANDURAN:
                case ArtifactKind.SPADE_NECROMANCY:
                case ArtifactKind.HEART_FIRE:
                case ArtifactKind.HEART_ICE:
                    //TODO: original
                    //  return Settings::Get().PriceLoyaltyVersion() ? ART_LOYALTY | LoyaltyLevel() : ART_LOYALTY;
                    return ArtifactLevel.ART_LOYALTY;
            }

            return ArtifactLevel.ART_NONE;
        }

        public string GetName()
        {
            return _(artifacts[(int) id].name);
        }

        public bool IsValid()
        {
            return id != ArtifactKind.UNKNOWN;
        }
    }
}