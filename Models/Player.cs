using InfiniteHelper.Global;
using InfiniteHelper.Models;
using System.Text.RegularExpressions;

namespace InfiniteHelper.Managers
{
    public class Player
    {
        private const string BONUS_START = "#------Quests------#";
        private const string BONUS_COUNT_PATTERN = @"^Completed: (?<bonus>\d+)\.$";
        private const string BONUS_PERCENT_PATTERN = @"^Bonus XP: [+-]?(?<bonus>[0-9]*[.]?[0-9]*)\%\.$";

        public int Level { get { return Globals.Core.CharacterFilter.Level; } }
        public XpState XP { get; set; } = new XpState();
        public LumState Lum { get; set; } = new LumState();
        public Attributes Attributes { get; set; } = new Attributes();
        public BankState Bank { get; set; } = new BankState();
        public int QuestBonusCount { get; set; } = 0;
        public double QuestBonusPercentage { get; set; } = 0;
        public string Server { get { return Globals.Core.CharacterFilter.Server; } }
        public string Account { get { return Globals.Core.CharacterFilter.AccountName; } }
        public string Name { get { return Globals.Core.CharacterFilter.Name; } }


        public void UpdateFromChatMessage(string message)
        {
            if (message.StartsWith(BONUS_START))
            {
                Globals.MidQb = !Globals.MidLumBonus;
            }

            var cleanMessage = message.Replace(",", "");

            var bonusCountPatternRegex = new Regex(BONUS_COUNT_PATTERN);
            if (bonusCountPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (Globals.MidQb && int.TryParse(bonusCountPatternRegex.Matches(cleanMessage)[0].Groups["bonus"].Value, out int parsedBonus))
                {
                    QuestBonusCount = parsedBonus;
                }
            }

            var bonusPercentPatternRegex = new Regex(BONUS_PERCENT_PATTERN);
            if (bonusPercentPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (Globals.MidQb && double.TryParse(bonusPercentPatternRegex.Matches(cleanMessage)[0].Groups["bonus"].Value, out double parsedBonus))
                {
                    QuestBonusPercentage = parsedBonus;
                }
            }

            Attributes.UpdateFromChatMessage(message);
            XP.UpdateFromChatMessage(message);
            Lum.UpdateFromChatMessage(message);
            Bank.UpdateFromChatMessage(message);
        }
    }
}
