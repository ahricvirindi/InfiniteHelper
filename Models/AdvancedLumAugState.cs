using InfiniteHelper.Managers;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace InfiniteHelper.Models
{
    public class AdvancedLumAugState
    {
        public AdvancedLumAugType LumAugType { get; set; }
        public int? Value { get; set; }
        public long RaiseCost { get { return CalculateRaiseCost(); } }


        public override string ToString()
        {
            return $"{LumAugType} -> Value {Value:n0} -> RaiseCost {RaiseCost:n0}";
        }

        private long CalculateRaiseCost()
        {
            long val = -1;

            if (!Value.HasValue)
            {
                return -1;
            }

            switch (LumAugType)
            {
                case AdvancedLumAugType.CriticalStrikeChance:
                    val = 5000000L + (long)Value * (1000000L + (long)Math.Round(100000.0));
                    break;
                case AdvancedLumAugType.CriticalStrikeDamage:
                    val = 3000000L + (long)Value * (500000L + (long)Math.Round(50000.0));
                    break;
                case AdvancedLumAugType.SpellComponent:
                    val = 500000L + (long)Value * (250000L + (long)Math.Round(25000.0));
                    break;
                case AdvancedLumAugType.MissileConsumption:
                    val = 500000L + (long)Value * (250000L + (long)Math.Round(25000.0));
                    break;
                case AdvancedLumAugType.SpellDuration:
                    val = 100000L + (long)Value * (250000L + (long)Math.Round(25000.0));
                    break;
                case AdvancedLumAugType.Vitality:
                    val = 100000L + (long)Value * (250000L + (long)Math.Round(25000.0));
                    break;
                case AdvancedLumAugType.CombatPetDamage:
                    val = 100000L + (long)Value * (250000L + (long)Math.Round(25000.0));
                    break;
                case AdvancedLumAugType.CreatureBuffValue:
                    val = 500000L + (long)Value * (750000L + (long)Math.Round(75000.0));
                    break;
            }

            return val;
        }
    }
}
