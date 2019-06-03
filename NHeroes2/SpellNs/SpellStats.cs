using static NHeroes2.ResourceNs.cost_t;
using static NHeroes2.SystemNs.Translation;

namespace NHeroes2.SpellNs
{
    public class SpellStats
    {
        internal static spellstats_t[] spells = new[]
        {
            //  name                      sp   mp  spr value  bits cost     description
            new spellstats_t("Unknown", 0, 0, 0, 0, 0, COST_NONE, "Unknown spell."),
            new spellstats_t(
                _("Fireball"), 9, 0, 8, 10, 0, COST_NONE,
                _("Causes a giant fireball to strike the selected area, damaging all nearby creatures.")
            ),
            new spellstats_t(
                _("Fireblast"), 15, 0, 9, 10, 0, COST_NONE,
                _(
                    "An improved version of fireball, fireblast affects two hexes around the center point of the spell, rather than one."
                )
            ),
            new spellstats_t(
                _("Lightning Bolt"), 7, 0, 4, 25, 0, COST_NONE,
                _("Causes a bolt of electrical energy to strike the selected creature.")
            ),
            new spellstats_t(
                _("Chain Lightning"), 15, 0, 5, 40, 0, COST_NONE,
                _(
                    "Causes a bolt of electrical energy to strike a selected creature, then strike the nearest creature with half damage, then strike the NEXT nearest creature with half again damage, and so on, until it becomes too weak to be harmful.  Warning:  This spell can hit your own creatures!"
                )
            ),
            new spellstats_t(
                _("Teleport"), 9, 0, 10, 0, 0, COST_NONE,
                _("Teleports the creature you select to any open position on the battlefield.")
            ),
            new spellstats_t(
                _("Cure"), 6, 0, 6, 5, 0, COST_NONE,
                _(
                    "Removes all negative spells cast upon one of your units, and restores up to %new spellstats_t(count} HP per level of spell power."
                )
            ),
            new spellstats_t(
                _("Mass Cure"), 15, 0, 2, 5, 0, COST_NONE,
                _(
                    "Removes all negative spells cast upon your forces, and restores up to %new spellstats_t(count} HP per level of spell power, per creature."
                )
            ),
            new spellstats_t(
                _("Resurrect"), 12, 0, 13, 50, 0, COST_NONE,
                _("Resurrects creatures from a damaged or dead unit until end of combat.")
            ),
            new spellstats_t(
                _("Resurrect True"), 15, 0, 12, 50, 0, COST_NONE,
                _("Resurrects creatures from a damaged or dead unit permanently.")
            ),
            new spellstats_t(_("Haste"), 3, 0, 14, 0, 0, COST_NONE,
                _("Increases the speed of any creature by %new spellstats_t(count}.")),
            new spellstats_t(_("Mass Haste"), 10, 0, 14, 0, 0, COST_NONE,
                _("Increases the speed of all of your creatures by %new spellstats_t(count}.")),
            new spellstats_t(_("spell|Slow"), 3, 0, 1, 0, 0, COST_NONE, _("Slows target to half movement rate.")),
            new spellstats_t(_("Mass Slow"), 15, 0, 1, 0, 0, COST_NONE, _("Slows all enemies to half movement rate.")),
            //
            new spellstats_t(_("Blind "), 6, 0, 21, 0, 0, COST_NONE,
                _("Clouds the affected creatures' eyes, preventing them from moving.")),
            new spellstats_t(_("Bless"), 3, 0, 7, 0, 0, COST_NONE,
                _("Causes the selected creatures to inflict maximum damage.")),
            new spellstats_t(_("Mass Bless"), 12, 0, 7, 0, 0, COST_NONE,
                _("Causes all of your units to inflict maximum damage.")),
            new spellstats_t(_("Stoneskin"), 3, 0, 31, 3, 0, COST_NONE,
                _("Magically increases the defense skill of the selected creatures.")),
            new spellstats_t(
                _("Steelskin"), 6, 0, 30, 5, 0, COST_NONE,
                _("Increases the defense skill of the targeted creatures.  This is an improved version of Stoneskin.")
            ),
            new spellstats_t(_("Curse"), 3, 0, 3, 0, 0, COST_NONE,
                _("Causes the selected creatures to inflict minimum damage.")),
            new spellstats_t(_("Mass Curse"), 12, 0, 3, 0, 0, COST_NONE,
                _("Causes all enemy troops to inflict minimum damage.")),
            new spellstats_t(_("Holy Word"), 9, 0, 22, 10, 0, COST_NONE, _("Damages all undead in the battle.")),
            new spellstats_t(
                _("Holy Shout"), 12, 0, 23, 20, 0, COST_NONE,
                _("Damages all undead in the battle.  This is an improved version of Holy Word.")
            ),
            new spellstats_t(_("Anti-Magic"), 7, 0, 17, 0, 0, COST_NONE,
                _("Prevents harmful magic against the selected creatures.")),
            new spellstats_t(_("Dispel Magic"), 5, 0, 18, 0, 0, COST_NONE,
                _("Removes all magic spells from a single target.")),
            new spellstats_t(_("Mass Dispel"), 12, 0, 18, 0, 0, COST_NONE,
                _("Removes all magic spells from all creatures.")),
            new spellstats_t(_("Magic Arrow"), 3, 0, 38, 10, 0, COST_NONE,
                _("Causes a magic arrow to strike the selected target.")),
            new spellstats_t(_("Berserker"), 12, 0, 19, 0, 0, COST_NONE,
                _("Causes a creature to attack its nearest neighbor.")),
            new spellstats_t(
                _("Armageddon"), 20, 0, 16, 50, 0, COST_NONE,
                _("Holy terror strikes the battlefield, causing severe damage to all creatures.")
            ),
            new spellstats_t(
                _("Elemental Storm"), 15, 0, 11, 25, 0, COST_NONE,
                _("Magical elements pour down on the battlefield, damaging all creatures.")
            ),
            new spellstats_t(
                _("Meteor Shower"), 15, 0, 24, 25, 0, COST_NONE,
                _("A rain of rocks strikes an area of the battlefield, damaging all nearby creatures.")
            ),
            new spellstats_t(_("Paralyze"), 9, 0, 20, 0, 0, COST_NONE,
                _("The targeted creatures are paralyzed, unable to move or retaliate.")),
            new spellstats_t(
                _("Hypnotize"), 15, 0, 37, 25, 0, COST_NONE,
                _(
                    "Brings a single enemy unit under your control for one combat round if its hits are less than %new spellstats_t(count} times the caster's spell power."
                )
            ),
            new spellstats_t(_("Cold Ray"), 6, 0, 36, 20, 0, COST_NONE,
                _("Drains body heat from a single enemy unit.")),
            new spellstats_t(
                _("Cold Ring"), 9, 0, 35, 10, 0, COST_NONE,
                _("Drains body heat from all units surrounding the center point, but not including the center point.")
            ),
            new spellstats_t(_("Disrupting Ray"), 7, 0, 34, 3, 0, COST_NONE,
                _("Reduces the defense rating of an enemy unit by three.")),
            new spellstats_t(_("Death Ripple"), 6, 0, 28, 5, 0, COST_NONE,
                _("Damages all living (non-undead) units in the battle.")),
            new spellstats_t(
                _("Death Wave"), 10, 0, 29, 10, 0, COST_NONE,
                _(
                    "Damages all living (non-undead) units in the battle.  This spell is an improved version of Death Ripple.")
            ),
            new spellstats_t(_("Dragon Slayer"), 6, 0, 32, 5, 0, COST_NONE,
                _("Greatly increases a unit's attack skill vs. Dragons.")),
            new spellstats_t(_("Blood Lust"), 3, 0, 27, 3, 0, COST_NONE, _("Increases a unit's attack skill.")),
            new spellstats_t(
                _("Animate Dead"), 10, 0, 25, 50, 0, COST_NONE,
                _("Resurrects creatures from a damaged or dead undead unit permanently.")
            ),
            new spellstats_t(
                _("Mirror Image"), 25, 0, 26, 0, 0, COST_NONE,
                _(
                    "Creates an illusionary unit that duplicates one of your existing units.  This illusionary unit does the same damages as the original, but will vanish if it takes any damage."
                )
            ),
            new spellstats_t(_("Shield"), 3, 0, 15, 2, 0, COST_NONE,
                _("Halves damage received from ranged attacks for a single unit.")),
            new spellstats_t(
                _("Mass Shield"), 7, 0, 15, 0, 0, COST_NONE,
                _("Halves damage received from ranged attacks for all of your units.")
            ),
            new spellstats_t(_("Summon Earth Elemental"), 30, 0, 56, 3, 0, COST_NONE,
                _("Summons Earth Elementals to fight for your army.")),
            new spellstats_t(_("Summon Air Elemental"), 30, 0, 57, 3, 0, COST_NONE,
                _("Summons Air Elementals to fight for your army.")),
            new spellstats_t(_("Summon Fire Elemental"), 30, 0, 58, 3, 0, COST_NONE,
                _("Summons Fire Elementals to fight for your army.")),
            new spellstats_t(_("Summon Water Elemental"), 30, 0, 59, 3, 0, COST_NONE,
                _("Summons Water Elementals to fight for your army.")),
            new spellstats_t(_("Earthquake"), 15, 0, 33, 0, 0, COST_NONE, _("Damages castle walls.")),
            new spellstats_t(_("View Mines"), 1, 0, 39, 0, 0, COST_NONE,
                _("Causes all mines across the land to become visible.")),
            new spellstats_t(_("View Resources"), 1, 0, 40, 0, 0, COST_NONE,
                _("Causes all resources across the land to become visible.")),
            new spellstats_t(_("View Artifacts"), 2, 0, 41, 0, 0, COST_NONE,
                _("Causes all artifacts across the land to become visible.")),
            new spellstats_t(_("View Towns"), 2, 0, 42, 0, 0, COST_NONE,
                _("Causes all towns and castles across the land to become visible.")),
            new spellstats_t(_("View Heroes"), 2, 0, 43, 0, 0, COST_NONE,
                _("Causes all Heroes across the land to become visible.")),
            new spellstats_t(_("View All"), 3, 0, 44, 0, 0, COST_NONE, _("Causes the entire land to become visible.")),
            new spellstats_t(
                _("Identify Hero"), 3, 0, 45, 0, 0, COST_NONE,
                _("Allows the caster to view detailed information on enemy Heroes.")
            ),
            new spellstats_t(
                _("Summon Boat"), 5, 0, 46, 0, 0, COST_NONE,
                _(
                    "Summons the nearest unoccupied, friendly boat to an adjacent shore location.  A friendly boat is one which you just built or were the most recent player to occupy."
                )
            ),
            new spellstats_t(
                _("Dimension Door"), 10, 0, 47, 0, 0, COST_NONE,
                _("Allows the caster to magically transport to a nearby location.")
            ),
            new spellstats_t(_("Town Gate"), 10, 0, 48, 0, 0, COST_NONE,
                _("Returns the caster to any town or castle currently owned.")),
            new spellstats_t(
                _("Town Portal"), 20, 0, 49, 0, 0, COST_NONE,
                _("Returns the hero to the town or castle of choice, provided it is controlled by you.")
            ),
            new spellstats_t(
                _("Visions"), 6, 0, 50, 3, 0, COST_NONE,
                _("Visions predicts the likely outcome of an encounter with a neutral army camp.")
            ),
            new spellstats_t(
                _("Haunt"), 8, 0, 51, 4, 0, COST_NONE,
                _(
                    "Haunts a mine you control with Ghosts.  This mine stops producing resources.  (If I can't keep it, nobody will!)"
                )
            ),
            new spellstats_t(
                _("Set Earth Guardian"), 15, 0, 52, 4, 0, COST_NONE,
                _("Sets Earth Elementals to guard a mine against enemy armies.")
            ),
            new spellstats_t(_("Set Air Guardian"), 15, 0, 53, 4, 0, COST_NONE,
                _("Sets Air Elementals to guard a mine against enemy armies.")),
            new spellstats_t(
                _("Set Fire Guardian"), 15, 0, 54, 4, 0, COST_NONE,
                _("Sets Fire Elementals to guard a mine against enemy armies.")
            ),
            new spellstats_t(
                _("Set Water Guardian"), 15, 0, 55, 4, 0, COST_NONE,
                _("Sets Water Elementals to guard a mine against enemy armies.")
            ),
            new spellstats_t("Random", 0, 0, 0, 0, 0, COST_NONE, "Random"),
            new spellstats_t("Random 1", 0, 0, 0, 0, 0, COST_NONE, "Random 1"),
            new spellstats_t("Random 2", 0, 0, 0, 0, 0, COST_NONE, "Random 2"),
            new spellstats_t("Random 3", 0, 0, 0, 0, 0, COST_NONE, "Random 3"),
            new spellstats_t("Random 4", 0, 0, 0, 0, 0, COST_NONE, "Random 4"),
            new spellstats_t("Random 5", 0, 0, 0, 0, 0, COST_NONE, "Random 5"),
            new spellstats_t("Stone", 0, 0, 0, 0, 0, COST_NONE, "Stone spell from Medusa."),
        };
    }
}