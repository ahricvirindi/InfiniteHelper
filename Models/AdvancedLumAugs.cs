using InfiniteHelper.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InfiniteHelper.Models
{
    public class AdvancedLumAugs
    {
        private const string RAISE_PATTERN = @"^\[AUG\] You have augmented your";

        public AdvancedLumAugState SpellComponents { get; set; } = new AdvancedLumAugState() {  LumAugType = AdvancedLumAugType.SpellComponent };
        public AdvancedLumAugState MissileConsumption { get; set; } = new AdvancedLumAugState() { LumAugType = AdvancedLumAugType.MissileConsumption };
        public AdvancedLumAugState SpellDuration { get; set; } = new AdvancedLumAugState() { LumAugType = AdvancedLumAugType.SpellDuration };
        public AdvancedLumAugState Vitality { get; set; } = new AdvancedLumAugState() { LumAugType = AdvancedLumAugType.Vitality };
        public AdvancedLumAugState CombatPetDamage { get; set; } = new AdvancedLumAugState() { LumAugType = AdvancedLumAugType.CombatPetDamage };
        public AdvancedLumAugState CriticalStrikeDamage { get; set; } = new AdvancedLumAugState() { LumAugType = AdvancedLumAugType.CriticalStrikeDamage };
        public AdvancedLumAugState CriticalStrikeChance { get; set; } = new AdvancedLumAugState() { LumAugType = AdvancedLumAugType.CriticalStrikeChance };
        public AdvancedLumAugState CreatureBuffValue { get; set; } = new AdvancedLumAugState() { LumAugType = AdvancedLumAugType.CreatureBuffValue };


        public void UpdateFromChatMessage(string message)
        {
            var cleanMessage = message.Replace(",", "");
            var parsedInt = 0;

            var raisePatternRegex = new Regex(RAISE_PATTERN);

            if (raisePatternRegex.Matches(cleanMessage).Count == 1)
            {
                Globals.SendCommand("/augs");
            }

            var augPatternRegex = new Regex(@"Spell Component: (?<val>\d+)x$");
            if (augPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (int.TryParse(augPatternRegex.Matches(cleanMessage)[0].Groups["val"].Value, out parsedInt))
                {
                    SpellComponents.Value = parsedInt;
                }
            }

            augPatternRegex = new Regex(@"Missile Consumption: (?<val>\d+)x$");
            if (augPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (int.TryParse(augPatternRegex.Matches(cleanMessage)[0].Groups["val"].Value, out parsedInt))
                {
                    MissileConsumption.Value = parsedInt;
                }
            }

            augPatternRegex = new Regex(@"Spell Duration: (?<val>\d+)x$");
            if (augPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (int.TryParse(augPatternRegex.Matches(cleanMessage)[0].Groups["val"].Value, out parsedInt))
                {
                    SpellDuration.Value = parsedInt;
                }
            }

            augPatternRegex = new Regex(@"Vitality: (?<val>\d+)x$");
            if (augPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (int.TryParse(augPatternRegex.Matches(cleanMessage)[0].Groups["val"].Value, out parsedInt))
                {
                    Vitality.Value = parsedInt;
                }
            }

            augPatternRegex = new Regex(@"Combat Pet Damage: (?<val>\d+)x$");
            if (augPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (int.TryParse(augPatternRegex.Matches(cleanMessage)[0].Groups["val"].Value, out parsedInt))
                {
                    CombatPetDamage.Value = parsedInt;
                }
            }

            augPatternRegex = new Regex(@"Critical Strike Chance: (?<val>\d+)x$");
            if (augPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (int.TryParse(augPatternRegex.Matches(cleanMessage)[0].Groups["val"].Value, out parsedInt))
                {
                    CriticalStrikeChance.Value = parsedInt;
                }
            }

            augPatternRegex = new Regex(@"Critical Strike Damage: (?<val>\d+)x$");
            if (augPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (int.TryParse(augPatternRegex.Matches(cleanMessage)[0].Groups["val"].Value, out parsedInt))
                {
                    CriticalStrikeDamage.Value = parsedInt;
                }
            }

            augPatternRegex = new Regex(@"Creature Buff Value: (?<val>\d+)x$");
            if (augPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (int.TryParse(augPatternRegex.Matches(cleanMessage)[0].Groups["val"].Value, out parsedInt))
                {
                    CreatureBuffValue.Value = parsedInt;
                }
            }
        }
    }
}
