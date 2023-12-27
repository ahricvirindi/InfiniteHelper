using InfiniteHelper.Global;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace InfiniteHelper.Models
{
    public class Attributes
    {
        private const string RAISE_PATTERN = @"^You have increased your \w+ to \d+! XP spent ";
        public AttributeState Strength { get; set; } = new AttributeState { AttributeType = Decal.Adapter.Wrappers.CharFilterAttributeType.Strength };
        public AttributeState Endurance { get; set; } = new AttributeState { AttributeType = Decal.Adapter.Wrappers.CharFilterAttributeType.Endurance };
        public AttributeState Coordination { get; set; } = new AttributeState { AttributeType = Decal.Adapter.Wrappers.CharFilterAttributeType.Coordination };
        public AttributeState Quickness { get; set; } = new AttributeState { AttributeType = Decal.Adapter.Wrappers.CharFilterAttributeType.Quickness };
        public AttributeState Focus { get; set; } = new AttributeState { AttributeType = Decal.Adapter.Wrappers.CharFilterAttributeType.Focus };
        public AttributeState Self { get; set; } = new AttributeState { AttributeType = Decal.Adapter.Wrappers.CharFilterAttributeType.Self };

        public void UpdateFromChatMessage(string message)
        {
            var cleanMessage = message.Replace(",", "");
            var raisePatternRegex = new Regex(RAISE_PATTERN);

            if (raisePatternRegex.Matches(cleanMessage).Count == 1)
            {
                Globals.UI.Refresh();
            }
        }
    }
}
