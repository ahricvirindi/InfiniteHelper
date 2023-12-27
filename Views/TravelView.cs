using InfiniteHelper.Global;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace InfiniteHelper.Views
{
    public class TravelView
    {
        private MyClasses.MetaViewWrappers.IStaticText lblTravelMessage;

        private MyClasses.MetaViewWrappers.IButton btnMarketplaceRecall;
        private MyClasses.MetaViewWrappers.IButton btnHouseRecall;
        private MyClasses.MetaViewWrappers.IButton btnAllegianceMansionRecall;
        private MyClasses.MetaViewWrappers.IButton btnAllegianceHometownRecall;
        private MyClasses.MetaViewWrappers.IButton btnLifestoneRecall;

        private bool HasShutdown { get; set; } = false;


        public void Refresh()
        {
            if (HasShutdown) return;
        }

        public void Init()
        {
            lblTravelMessage = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblTrackingMessage");

            btnMarketplaceRecall = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnMarketplaceRecall");
            btnHouseRecall = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnHouseRecall");
            btnAllegianceMansionRecall = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnAllegianceMansionRecall");
            btnAllegianceHometownRecall = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnAllegianceHometownRecall");
            btnLifestoneRecall = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnLifestoneRecall");

            btnMarketplaceRecall.Hit += new EventHandler(btnMarketplaceRecall_Hit);
            btnHouseRecall.Hit += new EventHandler(btnHouseRecall_Hit);
            btnAllegianceMansionRecall.Hit += new EventHandler(btnAllegianceMansionRecall_Hit);
            btnAllegianceHometownRecall.Hit += new EventHandler(btnAllegianceHometownRecall_Hit);
            btnLifestoneRecall.Hit += new EventHandler(btnLifestoneRecall_Hit);
        }

        public void Shutdown()
        {
            HasShutdown = true;

            lblTravelMessage = null;

            btnMarketplaceRecall.Hit -= new EventHandler(btnMarketplaceRecall_Hit);
            btnHouseRecall.Hit -= new EventHandler(btnHouseRecall_Hit);
            btnAllegianceMansionRecall.Hit -= new EventHandler(btnAllegianceMansionRecall_Hit);
            btnAllegianceHometownRecall.Hit -= new EventHandler(btnAllegianceHometownRecall_Hit);
            btnLifestoneRecall.Hit -= new EventHandler(btnLifestoneRecall_Hit);

            btnMarketplaceRecall = null;
            btnHouseRecall = null;
            btnAllegianceMansionRecall = null;
            btnAllegianceHometownRecall = null;
            btnLifestoneRecall = null;
        }

        public void Disable(string message)
        {
            lblTravelMessage.Text = message;
        }

        void btnMarketplaceRecall_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/marketplace");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        void btnAllegianceMansionRecall_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/house mansion_recall");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        void btnHouseRecall_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/house recall");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        void btnAllegianceHometownRecall_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/allegiance hometown");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        void btnLifestoneRecall_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/lifestone");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }
    }
}
