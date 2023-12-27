using InfiniteHelper.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace InfiniteHelper.Models
{
    public class LumState
    {
        private const string BONUS_START = "#------Bonus Lum Stats------#";
        private const string BONUS_PATTERN = @"^\[Total\] [+-]?(?<bonus>[0-9]*[.]?[0-9]*)\%$";
        private const string GAIN_PATTERN = @"^You've banked (?<lum>\d+) Luminance\.$";

        public long Tracked { get; set; } = 1;
        public decimal? Bonus { get; set; }
        public AdvancedLumAugs AdvancedAugs { get; set; } = new AdvancedLumAugs();
        public LumAugs Augs { get; set; } = new LumAugs();
        public long PerHour { get { return CalculatePerHour(); } }


        public void UpdateFromChatMessage(string message)
        {
            var bonusPatternRegex = new Regex(BONUS_PATTERN);
            var gainPatternRegex = new Regex(GAIN_PATTERN);

            if (message.StartsWith(BONUS_START)) { 
                Globals.MidLumBonus = true; 
            }

            var cleanMessage = message.Replace(",", "");
            if (bonusPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (Globals.MidLumBonus && decimal.TryParse(bonusPatternRegex.Matches(cleanMessage)[0].Groups["bonus"].Value, out decimal parsedBonus))
                {
                    Bonus = parsedBonus;
                }
                Globals.MidLumBonus = false;
            }

            if (gainPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (long.TryParse(gainPatternRegex.Matches(cleanMessage)[0].Groups["lum"].Value, out long parsedGain))
                {
                    Tracked += parsedGain;
                }
            }

            AdvancedAugs.UpdateFromChatMessage(message);
        }

        private long CalculatePerHour()
        {
            if (Tracked <= 1) return -1;
            var val = (long)-1;

            var elapsed = (long)Math.Abs((DateTime.Now - Globals.TrackingStartedAt).TotalMinutes);
            if (elapsed <= 1) return -1;

            val = (long)(Tracked / elapsed * 60.0);

            return val;
        }
    }
}
