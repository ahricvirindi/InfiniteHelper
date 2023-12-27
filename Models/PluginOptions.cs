using InfiniteHelper.Global;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfiniteHelper.Models
{
    public class PluginOptions
    {
        [JsonIgnore]
        public PlayerOptions CurrentPlayer { get { return GetCurrent(); } }
        public Dictionary<string, PlayerOptions> Players { get; set; } = new Dictionary<string, PlayerOptions>();


        private PlayerOptions GetCurrent()
        {
            var current = new PlayerOptions();

            if (Globals.Options.Players.ContainsKey(Globals.OptionsCurrentPlayerKey))
            {
                current = Globals.Options.Players[Globals.OptionsCurrentPlayerKey];
            }

            return current;
        }
    }
}
