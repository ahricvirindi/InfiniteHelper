using System;
using System.Threading;
using Decal.Adapter.Wrappers;
using InfiniteHelper.Global;
using InfiniteHelper.Protocol;
using Newtonsoft.Json.Linq;

namespace InfiniteHelper.Managers
{
    public class EventManager
    {
        public void Init()
        {
            Globals.Core.MessageProcessed += new EventHandler<Decal.Adapter.MessageProcessedEventArgs>(OnCoreMessageProcessed);
            Globals.Core.CharacterFilter.ChangeExperience += OnChangeExperience;
            Globals.Core.ChatBoxMessage += OnChatboxMessage;
            Globals.Core.CharacterFilter.LoginComplete += new EventHandler(OnLogin);
        }
        public void Shutdown()
        {
            Globals.Core.MessageProcessed -= new EventHandler<Decal.Adapter.MessageProcessedEventArgs>(OnCoreMessageProcessed);
            Globals.Core.CharacterFilter.ChangeExperience -= OnChangeExperience;
            Globals.Core.ChatBoxMessage -= OnChatboxMessage;
            Globals.Core.CharacterFilter.LoginComplete -= new EventHandler(OnLogin);
        }

        private void OnChatboxMessage(object sender, Decal.Adapter.ChatTextInterceptEventArgs e)
        {
            Globals.Player.UpdateFromChatMessage(e.Text);
        }

        private void OnChangeExperience(object sender, Decal.Adapter.Wrappers.ChangeExperienceEventArgs e)
        {

        }

        private void OnChangeLum(long lumValue)
        {
            // NOTE: this is wonky if Infinite server auto-banks Lum
            if (lumValue > 0)
            {
                Globals.Player.Lum.Tracked += lumValue;
            }
        }

        public void OnLogin(object sender, EventArgs e)
        {
            Globals.LoadOptions();

            Globals.Player.Attributes.Strength.Template = Globals.Options.CurrentPlayer.Template.Strength;
            Globals.Player.Attributes.Endurance.Template = Globals.Options.CurrentPlayer.Template.Endurance;
            Globals.Player.Attributes.Coordination.Template = Globals.Options.CurrentPlayer.Template.Coordination;
            Globals.Player.Attributes.Quickness.Template = Globals.Options.CurrentPlayer.Template.Quickness;
            Globals.Player.Attributes.Focus.Template = Globals.Options.CurrentPlayer.Template.Focus;
            Globals.Player.Attributes.Self.Template = Globals.Options.CurrentPlayer.Template.Self;

            Globals.ResetTracking();
            Globals.UI.Init();
            Globals.Refresh();

            Globals.FinishedLogin = true;
        }

        public void OnQWordUpdate(int key, string value)
        {
            switch (key)
            {
                case (int)QWord.Luminance:
                    OnChangeLum(long.Parse(value));
                    break;
            }
        }

        private void OnDWordUpdate(int key, string value)
        {
            switch (key)
            {
                case (int)Augmentations.MightSeventhMule:
                    Globals.Player.XP.Augs.MightOfTheSeventhMule = long.Parse(value);
                    break;
                case (int)Augmentations.ShadowSeventhMule:
                    Globals.Player.XP.Augs.ShadowOfTheSeventhMule = long.Parse(value);
                    break;
                case (int)Augmentations.ClutchMiser:
                    Globals.Player.XP.Augs.ClutchOfTheMiser = long.Parse(value);
                    break;
                case (int)Augmentations.EnduringEnchantment:
                    Globals.Player.XP.Augs.EnduringEnchantment = long.Parse(value);
                    break;
                case (int)Augmentations.QuickLearner:
                    Globals.Player.XP.Augs.QuickLearner = long.Parse(value);
                    break;
                case (int)Augmentations.ReinforcementLugians:
                    Globals.Player.XP.Augs.ReinforcementOfTheLugians = long.Parse(value);
                    break;
                case (int)Augmentations.BleearghFortitude:
                    Globals.Player.XP.Augs.BleearghsFortitude = long.Parse(value);
                    break;
                case (int)Augmentations.OswaldEnchancement:
                    Globals.Player.XP.Augs.OswaldsEnhancement = long.Parse(value);
                    break;
                case (int)Augmentations.SiraluunBlessing:
                    Globals.Player.XP.Augs.SiraluunsBlessing = long.Parse(value);
                    break;
                case (int)Augmentations.EnduringCalm:
                    Globals.Player.XP.Augs.EnduringCalm = long.Parse(value);
                    break;
                case (int)Augmentations.SteadfastWill:
                    Globals.Player.XP.Augs.SteadfastWill = long.Parse(value);
                    break; 
            }
        }

        private void OnProtocolLogin(Decal.Adapter.MessageStruct properties)
        {
            if (!((properties.Value<int>("flags") & 0x00000080) > 0))
            {
                return;
            }

            short dwordcount = properties.Value<short>("dwordCount");
            for (short d = 0; d < dwordcount; ++d)
            {
                int key = properties.Struct("dwords").Struct(d).Value<int>("key");
                var sVal = properties.Struct("dwords").Struct(d).Value<string>("value");
                OnDWordUpdate(key, sVal);
            }

            short qwordcount = properties.Value<short>("qwordCount");
            for (short q = 0; q < qwordcount; ++q)
            {
                int key = properties.Struct("qwords").Struct(q).Value<int>("key");
                var sVal = properties.Struct("dwords").Struct(q).Value<string>("value");
                OnQWordUpdate(key, sVal);
            }
        }


        //Need this to track luminance..may not work on Inifnite servers because they auto-bank Lum
        private void OnCoreMessageProcessed(object sender, Decal.Adapter.MessageProcessedEventArgs e)
        {
            switch (e.Message.Type)
            {
                case (int)ProtocolMessage.CharacterQWordUpdate:
                    OnQWordUpdate(e.Message.Value<int>("key"), e.Message.Value<string>("value"));
                    break;
                case (int)ProtocolMessage.CharacterDWordUpdate:
                    OnDWordUpdate(e.Message.Value<int>("key"), e.Message.Value<string>("value"));
                    break;
                case (int)ProtocolMessage.OrderedMessage:
                    switch (e.Message.Value<int>("event"))
                    {
                        case (int)ProtocolMessage.CharacterLogin:
                            OnProtocolLogin(e.Message.Struct("properties"));
                            break;
                    }
                    break;
            }
        }
    }
}
