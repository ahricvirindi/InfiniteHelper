using Decal.Adapter.Wrappers;
using InfiniteHelper.Global;
using System;
using System.Text.RegularExpressions;

namespace InfiniteHelper.Models
{
    public class XpState
    {
        private const string BONUS_START = "#------Bonus XP Stats------#";
        private const string BONUS_PATTERN = @"^\[Total\] [+-]?(?<bonus>[0-9]*[.]?[0-9]*)\%$";

        public long Total { get { return Globals.Core.CharacterFilter.TotalXP; } }
        public decimal? Bonus { get; set; }
        public long StartedTrackingAtTotal { get; set; }
        public long Unassigned { get { return Globals.Core.CharacterFilter.UnassignedXP; } }
        public XpAugs Augs { get; set; } = new XpAugs();
        public long ToLevel { get { return CalculateXpToLevel(); } }
        public long NextLevel { get { return CalculatNextLevelXp(); } }
        public long PerHour { get { return CalculatePerHour(); } }
        public long Tracked { get { return Total - StartedTrackingAtTotal; } }
        public string ToLevelETA { get { return CalculateToLevelETA(); } }

        public void UpdateFromChatMessage(string message)
        {
            var bonusPatternRegex = new Regex(BONUS_PATTERN);

            if (message.StartsWith(BONUS_START))
            {
                Globals.MidXpBonus = true;
            }

            var cleanMessage = message.Replace(",", "");
            if (bonusPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (Globals.MidXpBonus && decimal.TryParse(bonusPatternRegex.Matches(cleanMessage)[0].Groups["bonus"].Value, out decimal parsedBonus))
                {
                    Bonus = parsedBonus;
                }
                Globals.MidXpBonus = false;
            }
        }

        private long CalculateXpToLevel()
        {
            if (Globals.Player.Level < 275)
            {
                return Globals.Core.CharacterFilter.XPToNextLevel;
            }

            return XpTable.CalcPostRetailXpToNextLevel(Globals.Player.Level, Total);
        }

        private long CalculatNextLevelXp()
        {
            if (Globals.Player.Level < 275)
            {
                return Globals.Core.CharacterFilter.TotalXP + Globals.Core.CharacterFilter.XPToNextLevel;
            }

            return XpTable.CalcPostRetailNextLevelXp(Globals.Player.Level);
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

        private string CalculateToLevelETA()
        {
            var eta = "TBD";
            var toLevel = CalculateXpToLevel();
            var perHour = CalculatePerHour();
            var perMinute = perHour / 60;

            if (perMinute <= 0) return eta;

            var minuteETA = toLevel / perMinute;

            // if longer than the literql max timespan value
            // just say forever
            if (minuteETA >= (TimeSpan.MaxValue.TotalMinutes - 1))
            {
                return "Forever";
            }

            var timeSpan = TimeSpan.FromMinutes(minuteETA);

            eta = Globals.ToReadableDurationString(timeSpan);

            return eta;
        }
    }
}
