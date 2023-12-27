using InfiniteHelper.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace InfiniteHelper.Models
{
    public class BankState
    {
        private const string ACCOUNT_PATTERN = @"^\[BANK\] Account Number: (?<account>\d+)$";
        private const string BALANCE_PATTERN = @"^\[BANK\] Account Balances: (?<pyreals>\d+) Pyreals \|\| (?<lum>\d+) Luminance \|\| (?<keys>\d+) Legendary Keys \|\| (?<repentence>\d+) Repentence Coins \|\| (?<wealth>\d+) Wealth Coins \|\| (?<protection>\d+) Protection Coins$";

        public long? Pyreals { get; set; }
        public long? Luminance { get; set; }
        public long? Lengendaries { get; set; }
        public int? Account { get; set; }
        public int? Repentence { get; set; }
        public int? Wealth { get; set; }
        public int? Protection { get; set; }


        public void UpdateFromChatMessage(string message)
        {
            if (!message.StartsWith("[BANK]"))
            {
                return;
            }

            var cleanMessage = message.Replace(",", "");
            var accountPatternRegex = new Regex(ACCOUNT_PATTERN);
            var balancePatternRegex = new Regex(BALANCE_PATTERN);
            var parsedInt = 0;

            if (accountPatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (int.TryParse(accountPatternRegex.Matches(cleanMessage)[0].Groups["account"].Value, out parsedInt))
                {
                    Account = parsedInt;
                }
            }

            if (balancePatternRegex.Matches(cleanMessage).Count == 1)
            {
                if (int.TryParse(balancePatternRegex.Matches(cleanMessage)[0].Groups["pyreals"].Value, out parsedInt))
                {
                    Pyreals = parsedInt;
                }
                if (int.TryParse(balancePatternRegex.Matches(cleanMessage)[0].Groups["lum"].Value, out parsedInt))
                {
                    Luminance = parsedInt;
                }
                if (int.TryParse(balancePatternRegex.Matches(cleanMessage)[0].Groups["keys"].Value, out parsedInt))
                {
                    Lengendaries = parsedInt;
                }
                if (int.TryParse(balancePatternRegex.Matches(cleanMessage)[0].Groups["repentence"].Value, out parsedInt))
                {
                    Repentence = parsedInt;
                }
                if (int.TryParse(balancePatternRegex.Matches(cleanMessage)[0].Groups["wealth"].Value, out parsedInt))
                {
                    Wealth = parsedInt;
                }
                if (int.TryParse(balancePatternRegex.Matches(cleanMessage)[0].Groups["protection"].Value, out parsedInt))
                {
                    Protection = parsedInt;
                }
            }
        }
    }
}
