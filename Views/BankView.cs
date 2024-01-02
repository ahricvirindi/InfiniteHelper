using InfiniteHelper.Global;
using InfiniteHelper.Managers;
using MyClasses.MetaViewWrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfiniteHelper.Views
{
    public class BankView
    {
        private MyClasses.MetaViewWrappers.IStaticText lblBankMessage;

        private MyClasses.MetaViewWrappers.IStaticText lblBankAccount;
        private MyClasses.MetaViewWrappers.IStaticText lblBankPyreals;
        private MyClasses.MetaViewWrappers.IStaticText lblBankKeys;
        private MyClasses.MetaViewWrappers.IStaticText lblBankLum;
        private MyClasses.MetaViewWrappers.IStaticText lblBankRC;
        private MyClasses.MetaViewWrappers.IStaticText lblBankWC;
        private MyClasses.MetaViewWrappers.IStaticText lblBankPC;

        private MyClasses.MetaViewWrappers.IButton btnBankWithdraw;
        private MyClasses.MetaViewWrappers.IButton btnBankDeposit;
        private MyClasses.MetaViewWrappers.IButton btnBankSend;
        private MyClasses.MetaViewWrappers.IButton btnBankDepositAll;
        private MyClasses.MetaViewWrappers.IButton btnBankRefresh;

        private MyClasses.MetaViewWrappers.ITextBox txtBankTarget;
        private MyClasses.MetaViewWrappers.ITextBox txtBankAmount;
        private MyClasses.MetaViewWrappers.ICombo ddlBankType;

        private bool HasShutdown { get; set; } = false;


        public void Refresh()
        {
            if (HasShutdown) return;

            lblBankAccount.Text = Globals.Player.Bank.Account.ToString();
            lblBankPyreals.Text = $"{Globals.Player.Bank.Pyreals:n0}";
            lblBankKeys.Text = $"{Globals.Player.Bank.Lengendaries:n0}";
            lblBankLum.Text = $"{Globals.Player.Bank.Luminance:n0}";
            lblBankRC.Text = $"{Globals.Player.Bank.Repentence:n0}";
            lblBankWC.Text = $"{Globals.Player.Bank.Wealth:n0}";
            lblBankPC.Text = $"{Globals.Player.Bank.Protection:n0}";
        }

        public void Init()
        {
            lblBankMessage = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblBankMessage");

            lblBankAccount = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblBankAccount");
            lblBankPyreals = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblBankPyreals");
            lblBankKeys = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblBankKeys");
            lblBankLum = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblBankLum");
            lblBankRC = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblBankRC");
            lblBankWC = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblBankWC");
            lblBankPC = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblBankPC");

            txtBankTarget = (MyClasses.MetaViewWrappers.ITextBox)Globals.UI.GetViewControl("txtBankTarget");
            txtBankAmount = (MyClasses.MetaViewWrappers.ITextBox)Globals.UI.GetViewControl("txtBankAmount");
            ddlBankType = (MyClasses.MetaViewWrappers.ICombo)Globals.UI.GetViewControl("ddlBankType");
            ddlBankType.Add("pyreals");
            ddlBankType.Add("keys");
            ddlBankType.Add("luminance");
            ddlBankType.Add("repentence");
            ddlBankType.Add("wealth");
            ddlBankType.Add("protection");

            btnBankWithdraw = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnBankWithdraw");
            btnBankDeposit = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnBankDeposit");
            btnBankSend = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnBankSend");
            btnBankDepositAll = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnBankDepositAll");
            btnBankRefresh = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnBankRefresh");

            btnBankWithdraw.Hit += new EventHandler(btnBankWithdraw_Hit);
            btnBankDeposit.Hit += new EventHandler(btnBankDeposit_Hit);
            btnBankSend.Hit += new EventHandler(btnBankSend_Hit);
            btnBankDepositAll.Hit += new EventHandler(btnBankDepositAll_Hit);
            btnBankRefresh.Hit += new EventHandler(btnBankRefresh_Hit);
        }

        public void Shutdown()
        {
            HasShutdown = true;

            lblBankMessage = null;

            lblBankAccount = null;
            lblBankPyreals = null;
            lblBankKeys = null;
            lblBankLum = null;
            lblBankRC = null;
            lblBankWC = null;
            lblBankPC = null;

            txtBankTarget = null;
            txtBankAmount = null;
            ddlBankType = null;

            btnBankWithdraw.Hit -= new EventHandler(btnBankWithdraw_Hit);
            btnBankDeposit.Hit -= new EventHandler(btnBankDeposit_Hit);
            btnBankSend.Hit -= new EventHandler(btnBankSend_Hit);
            btnBankDepositAll.Hit -= new EventHandler(btnBankDepositAll_Hit);
            btnBankRefresh.Hit -= new EventHandler(btnBankRefresh_Hit);

            btnBankWithdraw = null;
            btnBankDeposit = null;
            btnBankSend = null;
            btnBankDepositAll = null;
            btnBankRefresh = null;
        }

        public void Disable(string message)
        {
            lblBankMessage.Text = message;
        }

        private int SanitizeNumericTextbox(ITextBox textBox, int defaultValue = 0)
        {
            if (string.IsNullOrEmpty(textBox.Text)) textBox.Text = $"{defaultValue}";
            if (!int.TryParse(textBox.Text, out int value))
            {
                value = defaultValue;
                textBox.Text = $"{defaultValue}";
            }

            textBox.Text = $"{Math.Abs(value)}";

            return value;
        }

        void btnBankWithdraw_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                lblBankMessage.Text = "";
                SanitizeNumericTextbox(txtBankAmount);

                if (string.IsNullOrEmpty(txtBankAmount.Text) || txtBankAmount.Text.Equals("0"))
                {
                    var msg = "Please enter a valid amount to withdraw.";
                    Globals.WriteToChat(msg, ChatColors.RED);
                    lblBankMessage.Text = msg;

                    return;
                }

                Globals.SendCommand($"/bank withdraw {ddlBankType.Text[ddlBankType.Selected]} {txtBankAmount.Text}");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        void btnBankRefresh_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                lblBankMessage.Text = "";
                Globals.SendCommand("/bank account");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        void btnBankDeposit_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                lblBankMessage.Text = "";
                SanitizeNumericTextbox(txtBankAmount);

                if (string.IsNullOrEmpty(txtBankAmount.Text) || txtBankAmount.Text.Equals("0"))
                {
                    var msg = "Please enter a valid amount to deposit.";
                    Globals.WriteToChat(msg, ChatColors.RED);
                    lblBankMessage.Text = msg;

                    return;
                }

                Globals.SendCommand($"/bank deposit {ddlBankType.Text[ddlBankType.Selected]} {txtBankAmount.Text}");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        private void btnBankSend_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                lblBankMessage.Text = "";
                if (string.IsNullOrEmpty(txtBankTarget.Text))
                {
                    var msg = "Please enter a valid recipient to send to.";
                    Globals.WriteToChat(msg, ChatColors.RED);
                    lblBankMessage.Text = msg;

                    return;
                }

                SanitizeNumericTextbox(txtBankAmount);

                if (string.IsNullOrEmpty(txtBankAmount.Text) || txtBankAmount.Text.Equals("0"))
                {
                    var msg = "Please enter a valid amount to send.";
                    Globals.WriteToChat(msg, ChatColors.RED);
                    lblBankMessage.Text = msg;

                    return;
                }

                if ((new List<string>() { "protection", "repentence", "wealth" }).Contains( ddlBankType.Text[ddlBankType.Selected]))
                {
                    var msg = $"{ddlBankType.Text[ddlBankType.Selected]} cannot be sent to other players.";
                    Globals.WriteToChat(msg, ChatColors.RED);
                    lblBankMessage.Text = msg;

                    return;
                }

                Globals.SendCommand($"/bank send {txtBankTarget.Text} {ddlBankType.Text[ddlBankType.Selected]} {txtBankAmount.Text}");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        private void btnBankDepositAll_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                lblBankMessage.Text = "";
                Globals.SendCommand("/bank deposit all");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }
    }
}
