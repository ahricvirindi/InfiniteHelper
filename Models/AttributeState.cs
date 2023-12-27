using Decal.Adapter.Wrappers;
using InfiniteHelper.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfiniteHelper.Models
{
    public class AttributeState
    {
        public Decal.Adapter.Wrappers.CharFilterAttributeType AttributeType { get; set; }
        public int Template { get; set; } = 10;
        public int Innate { get { return Globals.Core.CharacterFilter.Attributes[AttributeType].Creation; } }
        public int Base { get { return Globals.Core.CharacterFilter.Attributes[AttributeType].Base; } }
        public int Buffed { get { return Globals.Core.CharacterFilter.Attributes[AttributeType].Buffed; } }
        public ulong RaiseCost { get { return CalculateRaiseCost(); } }
        public long RaiseCount { get { return CalculateRaiseCount(); } }


        public override string ToString()
        {
            return $"{AttributeType} -> Template {Template:n0} -> Augs {GetAugmentBonuses()} -> Innate {Innate:n0} -> Base {Base:n0} -> Buffed {Buffed:n0} -> RaiseCount {RaiseCount:n0} -> RaiseCost {RaiseCost:n0}";
        }

        private int GetAugmentBonuses()
        {
            int augOffset = 0;

            switch (this.AttributeType)
            {
                case CharFilterAttributeType.Strength:
                    augOffset = (int)Globals.Player.XP.Augs.ReinforcementOfTheLugians;
                    break;
                case CharFilterAttributeType.Endurance:
                    augOffset = (int)Globals.Player.XP.Augs.BleearghsFortitude;
                    break;
                case CharFilterAttributeType.Coordination:
                    augOffset = (int)Globals.Player.XP.Augs.OswaldsEnhancement;
                    break;
                case CharFilterAttributeType.Quickness:
                    augOffset = (int)Globals.Player.XP.Augs.SiraluunsBlessing;
                    break;
                case CharFilterAttributeType.Focus:
                    augOffset = (int)Globals.Player.XP.Augs.EnduringCalm;
                    break;
                case CharFilterAttributeType.Self:
                    augOffset = (int)Globals.Player.XP.Augs.SteadfastWill;
                    break;
            }

            return augOffset * 5;
        }

        private int CalculateRaiseCount()
        {
            int augOffset = GetAugmentBonuses();

            var raises = Innate - Template - augOffset;

            return raises;
        }

        private ulong CalculateRaiseCost(int quantity = 1)
        {
            if (Base - Innate != 190)
            {
                return 0;
            }

            if (quantity <= 0)
            {
                return 0;
            }

            Int64 raises = CalculateRaiseCount();

            ulong val = 0;

            for (int index = 0; index < quantity; ++index)
            {
                val += (ulong)Math.Round((10UL * (ulong)raises) * 329220194.0 * (0.10000000149011612 + 3.0 / 1000.0 * (ulong)raises));
                raises++;
            }

            return val;
        }
    }
}
