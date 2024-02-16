using Decal.Adapter;
using Decal.Adapter.Wrappers;
using InfiniteHelper.Managers;
using InfiniteHelper.Models;
using InfiniteHelper.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace InfiniteHelper.Global
{
    public static class Globals
    {
        public static string Path { get; set; }
        public static string OptionsPath { get { return $"{Path}\\InfiniteHelper.config"; } }
        public static string OptionsCurrentPlayerKey { get { return $"{Globals.Player.Server}::{Globals.Player.Name}"; } }
        public static PluginOptions Options { get; set; } = new PluginOptions();

        private static System.Windows.Forms.Timer Heartbeat = new System.Windows.Forms.Timer();
        public static bool FinishedLogin { get; set; }
        public static bool MidRefresh { get; set; }
        public static bool MidXpBonus { get; set; }
        public static bool MidLumBonus { get; set; }
        public static bool MidQb { get; set; }
        public static string LogFilePath { get; set; }
        public static PluginHost Host { get; set; }
        public static DateTime StartedAt { get; set; } = DateTime.Now;
        public static DateTime TrackingStartedAt { get; set; } = DateTime.Now;
        public static string TrackingSessionLength { get { return ToReadableDurationString(DateTime.Now - TrackingStartedAt); } }
        public static Player Player { get; set; } = new Player();
        public static MainView UI { get; set; } = new MainView();
        public static EventManager Events { get; set; } = new EventManager();
        public static CoreManager Core { get; set; }
        public static List<string> AllowedServers = new List<string>() { "LOCAL", "Infinite Frosthaven" };

        public static bool Allowed {  get {  return AllowedServers.Contains(Player.Server); } }


        public static void StartHeartbeat()
        {
            Heartbeat.Tick += new EventHandler(Heartbeat_Tick);
            Heartbeat.Interval = 5000;
            Heartbeat.Start();
        }

        private static void Heartbeat_Tick(object sender, EventArgs e)
        {
            if (FinishedLogin && !MidRefresh && Allowed)
            {
                RefreshUI();
            }
        }     

        public static void DumpObject(object o)
        {
            if (!Allowed)
            {
                UI.Disable();
                return;
            }

            string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Log(json);
        }

        public static void LoadOptions()
        {
            if (File.Exists(OptionsPath)) {
                Options = JsonConvert.DeserializeObject<PluginOptions>(File.ReadAllText(OptionsPath));
            }

            if (!Options.Players.ContainsKey(OptionsCurrentPlayerKey))
            {
                Options.Players.Add(OptionsCurrentPlayerKey, new PlayerOptions());
                SaveOptions();
            }
        }

        public static void SaveOptions()
        {
            File.WriteAllText(OptionsPath, JsonConvert.SerializeObject(Options, Formatting.Indented));
        }

        public static void DumpState()
        {
            if (!Allowed)
            {
                UI.Disable();
                return;
            }

            string prefix = "DUMP_STATE ::";
            WriteToChat($"{prefix} NOW :: {DateTime.Now}", ChatColors.GREEN);
            WriteToChat($"{prefix} ALLOWED :: {Allowed}", ChatColors.GREEN);
            WriteToChat($"{prefix} LOGGED_IN_AT :: {StartedAt}", ChatColors.GREEN);
            WriteToChat($"{prefix} TRACKING_STARTED_AT :: {TrackingStartedAt}", ChatColors.GREEN);
            WriteToChat($"{prefix} TRACKING_DURATION :: {Math.Abs((DateTime.Now - TrackingStartedAt).TotalMinutes):n0}", ChatColors.GREEN);
            WriteToChat($"{prefix}", ChatColors.GREEN);
            WriteToChat($"{prefix} SERVER :: {Player.Server}", ChatColors.GREEN);
            WriteToChat($"{prefix} NAME :: {Player.Name}", ChatColors.GREEN);
            WriteToChat($"{prefix} LEVEL :: {Player.Level:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix}", ChatColors.GREEN);
            WriteToChat($"{prefix} QB_COUNT :: {Player.QuestBonusCount:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} QB_PERCENT :: {Player.QuestBonusPercentage:n}%", ChatColors.GREEN);
            WriteToChat($"{prefix}", ChatColors.GREEN);
            WriteToChat($"{prefix} ATTR :: {Player.Attributes.Strength}", ChatColors.GREEN);
            WriteToChat($"{prefix} ATTR :: {Player.Attributes.Endurance}", ChatColors.GREEN);
            WriteToChat($"{prefix} ATTR :: {Player.Attributes.Coordination}", ChatColors.GREEN);
            WriteToChat($"{prefix} ATTR :: {Player.Attributes.Quickness}", ChatColors.GREEN);
            WriteToChat($"{prefix} ATTR :: {Player.Attributes.Focus}", ChatColors.GREEN);
            WriteToChat($"{prefix} ATTR :: {Player.Attributes.Self}", ChatColors.GREEN);
            WriteToChat($"{prefix}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP_AUG :: MightOfTheSeventhMule :: {Player.XP.Augs.MightOfTheSeventhMule}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP_AUG :: ShadowOfTheSeventhMule :: {Player.XP.Augs.ShadowOfTheSeventhMule}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP_AUG :: ClutchOfTheMiser :: {Player.XP.Augs.ClutchOfTheMiser}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP_AUG :: EnduringEnchantment :: {Player.XP.Augs.EnduringEnchantment}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP_AUG :: QuickLearner :: {Player.XP.Augs.QuickLearner}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP_AUG :: ReinforcementOfTheLugians :: {Player.XP.Augs.ReinforcementOfTheLugians}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP_AUG :: BleearghsFortitude :: {Player.XP.Augs.BleearghsFortitude}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP_AUG :: OswaldsEnhancement :: {Player.XP.Augs.OswaldsEnhancement}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP_AUG :: SiraluunsBlessing :: {Player.XP.Augs.SiraluunsBlessing}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP_AUG :: EnduringCalm :: {Player.XP.Augs.EnduringCalm}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP_AUG :: SteadfastWill :: {Player.XP.Augs.SteadfastWill}", ChatColors.GREEN);
            WriteToChat($"{prefix}", ChatColors.GREEN);
            WriteToChat($"{prefix} ADV_LUM_AUG :: {Player.Lum.AdvancedAugs.SpellComponents}", ChatColors.GREEN);
            WriteToChat($"{prefix} ADV_LUM_AUG :: {Player.Lum.AdvancedAugs.MissileConsumption}", ChatColors.GREEN);
            WriteToChat($"{prefix} ADV_LUM_AUG :: {Player.Lum.AdvancedAugs.SpellDuration}", ChatColors.GREEN);
            WriteToChat($"{prefix} ADV_LUM_AUG :: {Player.Lum.AdvancedAugs.Vitality}", ChatColors.GREEN);
            WriteToChat($"{prefix} ADV_LUM_AUG :: {Player.Lum.AdvancedAugs.CombatPetDamage}", ChatColors.GREEN);
            WriteToChat($"{prefix} ADV_LUM_AUG :: {Player.Lum.AdvancedAugs.CriticalStrikeChance}", ChatColors.GREEN);
            WriteToChat($"{prefix} ADV_LUM_AUG :: {Player.Lum.AdvancedAugs.CriticalStrikeDamage}", ChatColors.GREEN);
            WriteToChat($"{prefix} ADV_LUM_AUG :: {Player.Lum.AdvancedAugs.CreatureBuffValue}", ChatColors.GREEN);
            WriteToChat($"{prefix}", ChatColors.GREEN);
            WriteToChat($"{prefix} BANK :: ACCOUNT :: {Player.Bank.Account}", ChatColors.GREEN);
            WriteToChat($"{prefix} BANK :: PYREALS :: {Player.Bank.Pyreals:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} BANK :: LUM :: {Player.Bank.Luminance:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} BANK :: LEGENDARIES :: {Player.Bank.Lengendaries:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} BANK :: REPENTENCE :: {Player.Bank.Repentence:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} BANK :: WEALTH :: {Player.Bank.Wealth:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} BANK :: PROTECTION :: {Player.Bank.Protection:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP :: TOTAL :: {Player.XP.Total:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP :: TRACKING_STARTED_AT_TOTAL :: {Player.XP.StartedTrackingAtTotal:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP :: TRACKED :: {Player.XP.Tracked:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP :: BONUS :: {Player.XP.Bonus:n0}%", ChatColors.GREEN);
            WriteToChat($"{prefix} XP :: UNASSIGNED :: {Player.XP.Unassigned:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP :: TO_LEVEL :: {Player.XP.ToLevel:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP :: NEXT_LEVEL :: {Player.XP.NextLevel:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP :: PER_HOUR :: {Player.XP.PerHour:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} XP :: LEVEL_ETA :: {Player.XP.ToLevelETA}", ChatColors.GREEN);
            WriteToChat($"{prefix}", ChatColors.GREEN);
            WriteToChat($"{prefix} LUM :: TRACKED :: {Player.Lum.Tracked:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix} LUM :: BONUS :: {Player.Lum.Bonus:n}%", ChatColors.GREEN);
            WriteToChat($"{prefix} LUM :: PER_HOUR :: {Player.Lum.PerHour:n0}", ChatColors.GREEN);
            WriteToChat($"{prefix}", ChatColors.GREEN);
        }

        public static void ResetTracking()
        {
            if (!Allowed)
            {
                UI.Disable();
                return;
            }

            TrackingStartedAt = DateTime.Now;
            Player.XP.StartedTrackingAtTotal = Player.XP.Total;
            Player.Lum.Tracked = 1;
        }

        public static void Refresh()
        {
            if (!Allowed)
            {
                UI.Disable();
                return;
            }

            MidRefresh = true;

            SendCommand("/augs");
            SendCommand("/stats");
            SendCommand("/bank account");
            SendCommand("/qb");

            RefreshUI();

            MidRefresh = false;
        }

        public static void RefreshUI()
        {
            if (!Allowed)
            {
                UI.Disable();
                return;
            }

            UI.Refresh();
        }

        public static void Log(Exception ex)
        {
            if (!Allowed)
            {
                UI.Disable();
                return;
            }

            System.IO.StreamWriter sw = new System.IO.StreamWriter(LogFilePath, true);
            sw.WriteLine("============================================================================");
            sw.WriteLine(DateTime.Now.ToString());
            sw.WriteLine("Error: " + ex.Message);
            sw.WriteLine("Source: " + ex.Source);
            sw.WriteLine("Stack: " + ex.StackTrace);
            if (ex.InnerException != null)
            {
                sw.WriteLine("Inner: " + ex.InnerException.Message);
                sw.WriteLine("Inner Stack: " + ex.InnerException.StackTrace);
            }
            sw.WriteLine("============================================================================");
            sw.WriteLine("");
            sw.Close();

            WriteToChat($"[InfiniteHelper] ERROR :: {ex.Message}", ChatColors.RED);
        }

        public static void Log(string message)
        {
            if (!Allowed)
            {
                UI.Disable();
                return;
            }

            System.IO.StreamWriter sw = new System.IO.StreamWriter(LogFilePath, true);
            sw.WriteLine("============================================================================");
            sw.WriteLine(DateTime.Now.ToString());
            sw.WriteLine(message);
            sw.WriteLine("============================================================================");
            sw.WriteLine("");
            sw.Close();

            WriteToChat($"[InfiniteHelper] DEBUG :: {message}", ChatColors.YELLOW);
        }

        public static void WriteToChat(string message, ChatColors color = ChatColors.PINK, int target = 1)
        {
            if (!Allowed)
            {
                UI.Disable();
                return;
            }

            if (Host == null) return;

            Host.Actions.AddChatText($"[InfiniteHelper] {message}", (int)color, target);
        }

        public static void SendCommand(string command)
        {
            if (!Allowed)
            {
                UI.Disable();
                return;
            }

            if (Host == null) return;

            Host.Actions.InvokeChatParser(command);
        }

        public static string ToReadableDurationString(TimeSpan span)
        {
            string formatted = "UNKNOWN";

            try
            {
                formatted = string.Format("{0}{1}{2}{3}",
                    span.Duration().Days > 0 ? string.Format("{0:0}d{1} ", span.Days, span.Days == 1 ? string.Empty : "") : string.Empty,
                    span.Duration().Hours > 0 ? string.Format("{0:0}h{1} ", span.Hours, span.Hours == 1 ? string.Empty : "") : string.Empty,
                    span.Duration().Minutes > 0 ? string.Format("{0:0}m{1} ", span.Minutes, span.Minutes == 1 ? string.Empty : "") : string.Empty,
                    span.Duration().Seconds > 0 ? string.Format("{0:0}s{1}", span.Seconds, span.Seconds == 1 ? string.Empty : "") : string.Empty);

                if (string.IsNullOrEmpty(formatted)) formatted = "0s";
            } catch(Exception e) { 
                formatted = "ERR";
            }

            return formatted;
        }

        public static string ToReadableDurationString(int minutes)
        {
            if (minutes > 0)
            {
                minutes *= -1;
            }

            var timeSpan = DateTime.Now - DateTime.Now.AddMinutes(minutes);
            return ToReadableDurationString(timeSpan);
        }
    }
}
