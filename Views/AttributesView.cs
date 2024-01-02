using InfiniteHelper.Global;
using InfiniteHelper.Managers;
using MyClasses.MetaViewWrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfiniteHelper.Views
{
    public class AttributesView
    {
        private MyClasses.MetaViewWrappers.IStaticText lblAttributesMessage;

        private MyClasses.MetaViewWrappers.IStaticText lblStrInnate;
        private MyClasses.MetaViewWrappers.IStaticText lblStrBase;
        private MyClasses.MetaViewWrappers.IStaticText lblStrBuffed;
        private MyClasses.MetaViewWrappers.IStaticText lblStrRaises;
        private MyClasses.MetaViewWrappers.IStaticText lblStrRaiseCost;

        private MyClasses.MetaViewWrappers.IStaticText lblEndInnate;
        private MyClasses.MetaViewWrappers.IStaticText lblEndBase;
        private MyClasses.MetaViewWrappers.IStaticText lblEndBuffed;
        private MyClasses.MetaViewWrappers.IStaticText lblEndRaises;
        private MyClasses.MetaViewWrappers.IStaticText lblEndRaiseCost;

        private MyClasses.MetaViewWrappers.IStaticText lblCoordInnate;
        private MyClasses.MetaViewWrappers.IStaticText lblCoordBase;
        private MyClasses.MetaViewWrappers.IStaticText lblCoordBuffed;
        private MyClasses.MetaViewWrappers.IStaticText lblCoordRaises;
        private MyClasses.MetaViewWrappers.IStaticText lblCoordRaiseCost;

        private MyClasses.MetaViewWrappers.IStaticText lblQuickInnate;
        private MyClasses.MetaViewWrappers.IStaticText lblQuickBase;
        private MyClasses.MetaViewWrappers.IStaticText lblQuickBuffed;
        private MyClasses.MetaViewWrappers.IStaticText lblQuickRaises;
        private MyClasses.MetaViewWrappers.IStaticText lblQuickRaiseCost;

        private MyClasses.MetaViewWrappers.IStaticText lblFocusInnate;
        private MyClasses.MetaViewWrappers.IStaticText lblFocusBase;
        private MyClasses.MetaViewWrappers.IStaticText lblFocusBuffed;
        private MyClasses.MetaViewWrappers.IStaticText lblFocusRaises;
        private MyClasses.MetaViewWrappers.IStaticText lblFocusRaiseCost;

        private MyClasses.MetaViewWrappers.IStaticText lblSelfInnate;
        private MyClasses.MetaViewWrappers.IStaticText lblSelfBase;
        private MyClasses.MetaViewWrappers.IStaticText lblSelfBuffed;
        private MyClasses.MetaViewWrappers.IStaticText lblSelfRaises;
        private MyClasses.MetaViewWrappers.IStaticText lblSelfRaiseCost;

        private MyClasses.MetaViewWrappers.IStaticText lblUnspentXp;

        private MyClasses.MetaViewWrappers.ITextBox txtStrTemplate;
        private MyClasses.MetaViewWrappers.ITextBox txtEndTemplate;
        private MyClasses.MetaViewWrappers.ITextBox txtCoordTemplate;
        private MyClasses.MetaViewWrappers.ITextBox txtQuickTemplate;
        private MyClasses.MetaViewWrappers.ITextBox txtFocusTemplate;
        private MyClasses.MetaViewWrappers.ITextBox txtSelfTemplate;

        private MyClasses.MetaViewWrappers.IButton btnStrRaise;
        private MyClasses.MetaViewWrappers.IButton btnEndRaise;
        private MyClasses.MetaViewWrappers.IButton btnCoordRaise;
        private MyClasses.MetaViewWrappers.IButton btnQuickRaise;
        private MyClasses.MetaViewWrappers.IButton btnFocusRaise;
        private MyClasses.MetaViewWrappers.IButton btnSelfRaise;
        private MyClasses.MetaViewWrappers.IButton btnAttributesRefresh;

        private bool HasShutdown { get; set; } = false;


        public void Refresh()
        {
            if (HasShutdown) return;

            if (string.IsNullOrEmpty(txtStrTemplate.Text)) txtStrTemplate.Text = Globals.Options.CurrentPlayer.Template.Strength.ToString();
            if (string.IsNullOrEmpty(txtEndTemplate.Text)) txtEndTemplate.Text = Globals.Options.CurrentPlayer.Template.Endurance.ToString();
            if (string.IsNullOrEmpty(txtCoordTemplate.Text)) txtCoordTemplate.Text = Globals.Options.CurrentPlayer.Template.Coordination.ToString();
            if (string.IsNullOrEmpty(txtQuickTemplate.Text)) txtQuickTemplate.Text = Globals.Options.CurrentPlayer.Template.Quickness.ToString();
            if (string.IsNullOrEmpty(txtFocusTemplate.Text)) txtFocusTemplate.Text = Globals.Options.CurrentPlayer.Template.Focus.ToString();
            if (string.IsNullOrEmpty(txtSelfTemplate.Text)) txtSelfTemplate.Text = Globals.Options.CurrentPlayer.Template.Self.ToString();

            lblStrInnate.Text = $"{Globals.Player.Attributes.Strength.Innate:n0}";
            lblStrBase.Text = $"{Globals.Player.Attributes.Strength.Base:n0}";
            lblStrBuffed.Text = $"{Globals.Player.Attributes.Strength.Buffed:n0}";
            lblStrRaises.Text = $"{Globals.Player.Attributes.Strength.RaiseCount:n0}";
            lblStrRaiseCost.Text = $"{Globals.Player.Attributes.Strength.RaiseCost:n0}";
            lblStrRaiseCost.TextColor = Convert.ToInt64(Globals.Player.Attributes.Strength.RaiseCost) < Globals.Player.XP.Unassigned ? System.Drawing.Color.Green : System.Drawing.Color.White;

            lblEndInnate.Text = $"{Globals.Player.Attributes.Endurance.Innate:n0}";
            lblEndBase.Text = $"{Globals.Player.Attributes.Endurance.Base:n0}";
            lblEndBuffed.Text = $"{Globals.Player.Attributes.Endurance.Buffed:n0}";
            lblEndRaises.Text = $"{Globals.Player.Attributes.Endurance.RaiseCount:n0}";
            lblEndRaiseCost.Text = $"{Globals.Player.Attributes.Endurance.RaiseCost:n0}";
            lblEndRaiseCost.TextColor = Convert.ToInt64(Globals.Player.Attributes.Endurance.RaiseCost) < Globals.Player.XP.Unassigned ? System.Drawing.Color.Green : System.Drawing.Color.White;

            lblCoordInnate.Text = $"{Globals.Player.Attributes.Coordination.Innate:n0}";
            lblCoordBase.Text = $"{Globals.Player.Attributes.Coordination.Base:n0}";
            lblCoordBuffed.Text = $"{Globals.Player.Attributes.Coordination.Buffed:n0}";
            lblCoordRaises.Text = $"{Globals.Player.Attributes.Coordination.RaiseCount:n0}";
            lblCoordRaiseCost.Text = $"{Globals.Player.Attributes.Coordination.RaiseCost:n0}";
            lblCoordRaiseCost.TextColor = Convert.ToInt64(Globals.Player.Attributes.Coordination.RaiseCost) < Globals.Player.XP.Unassigned ? System.Drawing.Color.Green : System.Drawing.Color.White;

            lblQuickInnate.Text = $"{Globals.Player.Attributes.Quickness.Innate:n0}";
            lblQuickBase.Text = $"{Globals.Player.Attributes.Quickness.Base:n0}";
            lblQuickBuffed.Text = $"{Globals.Player.Attributes.Quickness.Buffed:n0}";
            lblQuickRaises.Text = $"{Globals.Player.Attributes.Quickness.RaiseCount:n0}";
            lblQuickRaiseCost.Text = $"{Globals.Player.Attributes.Quickness.RaiseCost:n0}";
            lblQuickRaiseCost.TextColor = Convert.ToInt64(Globals.Player.Attributes.Quickness.RaiseCost) < Globals.Player.XP.Unassigned ? System.Drawing.Color.Green : System.Drawing.Color.White;

            lblFocusInnate.Text = $"{Globals.Player.Attributes.Focus.Innate:n0}";
            lblFocusBase.Text = $"{Globals.Player.Attributes.Focus.Base:n0}";
            lblFocusBuffed.Text = $"{Globals.Player.Attributes.Focus.Buffed:n0}";
            lblFocusRaises.Text = $"{Globals.Player.Attributes.Focus.RaiseCount:n0}";
            lblFocusRaiseCost.Text = $"{Globals.Player.Attributes.Focus.RaiseCost:n0}";
            lblFocusRaiseCost.TextColor = Convert.ToInt64(Globals.Player.Attributes.Focus.RaiseCost) < Globals.Player.XP.Unassigned ? System.Drawing.Color.Green : System.Drawing.Color.White;

            lblSelfInnate.Text = $"{Globals.Player.Attributes.Self.Innate:n0}";
            lblSelfBase.Text = $"{Globals.Player.Attributes.Self.Base:n0}";
            lblSelfBuffed.Text = $"{Globals.Player.Attributes.Self.Buffed:n0}";
            lblSelfRaises.Text = $"{Globals.Player.Attributes.Self.RaiseCount:n0}";
            lblSelfRaiseCost.Text = $"{Globals.Player.Attributes.Self.RaiseCost:n0}";
            lblSelfRaiseCost.TextColor = Convert.ToInt64(Globals.Player.Attributes.Self.RaiseCost) < Globals.Player.XP.Unassigned ? System.Drawing.Color.Green : System.Drawing.Color.White;

            lblUnspentXp.Text = $"{Globals.Player.XP.Unassigned:n0}";
        }

        public void Init()
        {
            lblAttributesMessage = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblAttributesMessage");

            lblStrInnate = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblStrInnate");
            lblStrBase = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblStrBase");
            lblStrBuffed = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblStrBuffed");
            lblStrRaises = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblStrRaises");
            lblStrRaiseCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblStrRaiseCost");

            lblEndInnate = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblEndInnate");
            lblEndBase = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblEndBase");
            lblEndBuffed = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblEndBuffed");
            lblEndRaises = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblEndRaises");
            lblEndRaiseCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblEndRaiseCost");

            lblCoordInnate = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblCoordInnate");
            lblCoordBase = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblCoordBase");
            lblCoordBuffed = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblCoordBuffed");
            lblCoordRaises = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblCoordRaises");
            lblCoordRaiseCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblCoordRaiseCost");

            lblQuickInnate = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblQuickInnate");
            lblQuickBase = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblQuickBase");
            lblQuickBuffed = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblQuickBuffed");
            lblQuickRaises = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblQuickRaises");
            lblQuickRaiseCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblQuickRaiseCost");

            lblFocusInnate = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblFocusInnate");
            lblFocusBase = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblFocusBase");
            lblFocusBuffed = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblFocusBuffed");
            lblFocusRaises = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblFocusRaises");
            lblFocusRaiseCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblFocusRaiseCost");

            lblSelfInnate = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblSelfInnate");
            lblSelfBase = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblSelfBase");
            lblSelfBuffed = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblSelfBuffed");
            lblSelfRaises = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblSelfRaises");
            lblSelfRaiseCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblSelfRaiseCost");

            txtStrTemplate = (MyClasses.MetaViewWrappers.ITextBox)Globals.UI.GetViewControl("txtStrTemplate");
            txtEndTemplate = (MyClasses.MetaViewWrappers.ITextBox)Globals.UI.GetViewControl("txtEndTemplate");
            txtCoordTemplate = (MyClasses.MetaViewWrappers.ITextBox)Globals.UI.GetViewControl("txtCoordTemplate");
            txtQuickTemplate = (MyClasses.MetaViewWrappers.ITextBox)Globals.UI.GetViewControl("txtQuickTemplate");
            txtFocusTemplate = (MyClasses.MetaViewWrappers.ITextBox)Globals.UI.GetViewControl("txtFocusTemplate");
            txtSelfTemplate = (MyClasses.MetaViewWrappers.ITextBox)Globals.UI.GetViewControl("txtSelfTemplate");

            btnStrRaise = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnStrRaise");
            btnEndRaise = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnEndRaise");
            btnCoordRaise = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnCoordRaise");
            btnQuickRaise = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnQuickRaise");
            btnFocusRaise = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnFocusRaise");
            btnSelfRaise = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnSelfRaise");

            lblUnspentXp = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblUnspentXp");

            btnAttributesRefresh = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnAttributesRefresh");

            btnStrRaise.Hit += new EventHandler(btnStrRaise_Hit);
            btnEndRaise.Hit += new EventHandler(btnEndRaise_Hit);
            btnCoordRaise.Hit += new EventHandler(btnCoordRaise_Hit);
            btnQuickRaise.Hit += new EventHandler(btnQuickRaise_Hit);
            btnFocusRaise.Hit += new EventHandler(btnFocusRaise_Hit);
            btnSelfRaise.Hit += new EventHandler(btnSelfRaise_Hit);
            btnAttributesRefresh.Hit += new EventHandler(btnAttributesRefresh_Hit);

            if (GetHasNoTemplateValues())
            {
                var msg = "Starting template not entered. Please modify your starting attributes for accuracy.";
                Globals.WriteToChat(msg, ChatColors.RED);
                lblAttributesMessage.Text = msg;
            }

        }

        public void Shutdown()
        {
            HasShutdown = true;

            lblAttributesMessage = null;

            lblStrInnate = null;
            lblStrBase = null;
            lblStrBuffed = null;
            lblStrRaises = null;
            lblStrRaiseCost = null;

            lblEndInnate = null;
            lblEndBase = null;
            lblEndBuffed = null;
            lblEndRaises = null;
            lblEndRaiseCost = null;

            lblCoordInnate = null;
            lblCoordBase = null;
            lblCoordBuffed = null;
            lblCoordRaises = null;
            lblCoordRaiseCost = null;

            lblQuickInnate = null;
            lblQuickBase = null;
            lblQuickBuffed = null;
            lblQuickRaises = null;
            lblQuickRaiseCost = null;

            lblFocusInnate = null;
            lblFocusBase = null;
            lblFocusBuffed = null;
            lblFocusRaises = null;
            lblFocusRaiseCost = null;

            lblSelfInnate = null;
            lblSelfBase = null;
            lblSelfBuffed = null;
            lblSelfRaises = null;
            lblSelfRaiseCost = null;

            txtStrTemplate = null;
            txtEndTemplate = null;
            txtCoordTemplate = null;
            txtQuickTemplate = null;
            txtFocusTemplate = null;
            txtSelfTemplate = null;

            btnStrRaise.Hit -= new EventHandler(btnStrRaise_Hit);
            btnEndRaise.Hit -= new EventHandler(btnEndRaise_Hit);
            btnCoordRaise.Hit -= new EventHandler(btnCoordRaise_Hit);
            btnQuickRaise.Hit -= new EventHandler(btnQuickRaise_Hit);
            btnFocusRaise.Hit -= new EventHandler(btnFocusRaise_Hit);
            btnSelfRaise.Hit -= new EventHandler(btnSelfRaise_Hit);
            btnAttributesRefresh.Hit -= new EventHandler(btnAttributesRefresh_Hit);

            btnStrRaise = null;
            btnEndRaise = null;
            btnCoordRaise = null;
            btnQuickRaise = null;
            btnFocusRaise = null;
            btnSelfRaise = null;

            lblUnspentXp = null;

            btnAttributesRefresh = null;
        }

        public void Disable(string message)
        {
            lblAttributesMessage.Text = message;
        }

        private void btnAttributesRefresh_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                SanitizeAndSaveTemplate();
                Refresh();
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        private void SanitizeAndSaveTemplate()
        {
            Globals.Player.Attributes.Strength.Template = SanitizeNumericTextbox(txtStrTemplate, "strength");
            Globals.Player.Attributes.Endurance.Template = SanitizeNumericTextbox(txtEndTemplate, "endurance");
            Globals.Player.Attributes.Coordination.Template = SanitizeNumericTextbox(txtCoordTemplate, "coordination");
            Globals.Player.Attributes.Quickness.Template = SanitizeNumericTextbox(txtQuickTemplate, "quickness");
            Globals.Player.Attributes.Focus.Template = SanitizeNumericTextbox(txtFocusTemplate, "focus");
            Globals.Player.Attributes.Self.Template = SanitizeNumericTextbox(txtSelfTemplate, "self");

            // make sure current template is updated from player state into options
            Globals.Options.CurrentPlayer.Template.Strength = Globals.Player.Attributes.Strength.Template;
            Globals.Options.CurrentPlayer.Template.Endurance = Globals.Player.Attributes.Endurance.Template;
            Globals.Options.CurrentPlayer.Template.Coordination = Globals.Player.Attributes.Coordination.Template;
            Globals.Options.CurrentPlayer.Template.Quickness = Globals.Player.Attributes.Quickness.Template;
            Globals.Options.CurrentPlayer.Template.Focus = Globals.Player.Attributes.Focus.Template;
            Globals.Options.CurrentPlayer.Template.Self = Globals.Player.Attributes.Self.Template;

            Globals.SaveOptions();
        }
        
        private int SanitizeNumericTextbox(ITextBox textBox, string label, int defaultValue = 10)
        {
            if (string.IsNullOrEmpty(textBox.Text)) textBox.Text = $"{defaultValue}";
            if (!int.TryParse(textBox.Text, out int value))
            {
                value = defaultValue;
                textBox.Text = $"{defaultValue}";

                var msg = $"{textBox.Text} is not a valid value for {label} template attribute.  Set to default value of {defaultValue}.";
                Globals.WriteToChat(msg, ChatColors.RED);
                lblAttributesMessage.Text = msg;
            }

            if (value < 10) value = 10;
            if (value > 100) value = 100;

            textBox.Text = $"{Math.Abs(value)}";

            return value;
        }

        private void btnStrRaise_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/raise str 1");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        private void btnEndRaise_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/raise end 1");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        private void btnCoordRaise_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/raise coord 1");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        private void btnQuickRaise_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/raise quick 1");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        private void btnFocusRaise_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/raise focus 1");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        private void btnSelfRaise_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/raise self 1");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        private bool GetHasNoTemplateValues()
        {
            return (Globals.Options.CurrentPlayer.Template.Strength == 10 &&
                Globals.Options.CurrentPlayer.Template.Endurance == 10 &&
                Globals.Options.CurrentPlayer.Template.Coordination == 10 &&
                Globals.Options.CurrentPlayer.Template.Quickness == 10 &&
                Globals.Options.CurrentPlayer.Template.Focus == 10 &&
                Globals.Options.CurrentPlayer.Template.Self == 10);
        }
    }
}
