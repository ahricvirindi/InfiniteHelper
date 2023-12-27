using Decal.Adapter.Wrappers;
using InfiniteHelper.Global;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace InfiniteHelper.Views
{
    public class TrackingView
    {
        private MyClasses.MetaViewWrappers.IStaticText lblTrackingMessage;

        private MyClasses.MetaViewWrappers.IButton btnResetTracking;
        private MyClasses.MetaViewWrappers.IButton btnDebug;
        private MyClasses.MetaViewWrappers.IButton btnRefresh;
        private MyClasses.MetaViewWrappers.IButton btnHelp;

        private MyClasses.MetaViewWrappers.IStaticText lblServer;
        private MyClasses.MetaViewWrappers.IStaticText lblName;
        private MyClasses.MetaViewWrappers.IStaticText lblLoggedInAt;
        private MyClasses.MetaViewWrappers.IStaticText lblTrackingStartedAt;
        private MyClasses.MetaViewWrappers.IStaticText lblTrackingDuration;
        private MyClasses.MetaViewWrappers.IStaticText lblXPToLevel;
        private MyClasses.MetaViewWrappers.IStaticText lblXPPerHour;
        private MyClasses.MetaViewWrappers.IStaticText lblLumPerHour;
        private MyClasses.MetaViewWrappers.IStaticText lblQB;
        private MyClasses.MetaViewWrappers.IStaticText lblQBPercent;
        private MyClasses.MetaViewWrappers.IStaticText lblXPBonus;
        private MyClasses.MetaViewWrappers.IStaticText lblLumBonus;
        private MyClasses.MetaViewWrappers.IStaticText lblXPTracked;
        private MyClasses.MetaViewWrappers.IStaticText lblLevelETA;
        private MyClasses.MetaViewWrappers.IStaticText lblLumTracked;

        private bool HasShutdown { get; set; } = false;


        public void Refresh()
        {
            if (HasShutdown) return;

            lblServer.Text = Globals.Player.Server;
            lblName.Text = Globals.Player.Name;
            lblLoggedInAt.Text = Globals.StartedAt.ToString("yyyy-MM-dd HH:mm:ss");
            lblTrackingStartedAt.Text = Globals.TrackingStartedAt.ToString("yyyy-MM-dd HH:mm:ss");
            lblTrackingDuration.Text = Globals.TrackingSessionLength;
            lblXPToLevel.Text = $"{Globals.Player.XP.ToLevel:n0}";
            lblXPPerHour.Text = $"{Globals.Player.XP.PerHour:n0}";
            lblLumPerHour.Text = $"{Globals.Player.Lum.PerHour:n0}";
            lblQB.Text = $"{Globals.Player.QuestBonusCount:n0}";
            lblQBPercent.Text = $"{Globals.Player.QuestBonusPercentage:n}%";
            lblXPBonus.Text = $"{Globals.Player.XP.Bonus:n}%";
            lblLumBonus.Text = $"{Globals.Player.Lum.Bonus:n}%";
            lblXPTracked.Text = $"{Globals.Player.XP.Tracked:n0}";
            lblLevelETA.Text = $"{Globals.Player.XP.ToLevelETA}";
            lblLumTracked.Text = $"{Globals.Player.Lum.Tracked:n0}";
        }

        public void Init()
        {
            lblTrackingMessage = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblTrackingMessage");

            lblServer = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblServer");
            lblName = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblName");
            lblLoggedInAt = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblLoggedInAt");
            lblTrackingStartedAt = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblTrackingStartedAt");
            lblTrackingDuration = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblTrackingDuration");
            lblXPToLevel = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblXPToLevel");
            lblXPPerHour = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblXPPerHour");
            lblLumPerHour = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblLumPerHour");
            lblQB = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblQB");
            lblQBPercent = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblQBPercent");
            lblXPBonus = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblXPBonus");
            lblLumBonus = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblLumBonus");
            lblXPTracked = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblXPTracked");
            lblLevelETA = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblLevelETA");
            lblLumTracked = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblLumTracked");

            btnResetTracking = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnResetTracking");
            btnDebug = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnDebug");
            btnRefresh = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnRefresh");
            btnHelp = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnHelp");

            btnResetTracking.Hit += new EventHandler(btnResetTracking_Hit);
            btnRefresh.Hit += new EventHandler(btnRefresh_Hit);
            btnDebug.Hit += new EventHandler(btnDebug_Hit);
            btnHelp.Hit += new EventHandler(btnHelp_Hit);
        }

        public void Shutdown()
        {
            HasShutdown = true;

            lblTrackingMessage = null;

            lblServer = null;
            lblName = null;
            lblLoggedInAt = null;
            lblTrackingStartedAt = null;
            lblTrackingDuration = null;
            lblXPToLevel = null;
            lblXPPerHour = null;
            lblLumPerHour = null;
            lblQB = null;
            lblQBPercent = null;
            lblXPBonus = null;
            lblLumBonus = null;
            lblXPTracked = null;
            lblLevelETA = null;
            lblLumTracked = null;

            btnResetTracking.Hit -= new EventHandler(btnResetTracking_Hit);
            btnDebug.Hit -= new EventHandler(btnDebug_Hit);
            btnRefresh.Hit -= new EventHandler(btnRefresh_Hit);
            btnHelp.Hit -= new EventHandler(btnHelp_Hit);

            btnResetTracking = null;
            btnDebug = null;
            btnRefresh = null;
            btnHelp = null;
        }

        public void Disable(string message)
        {
            lblTrackingMessage.Text = message;
        }

        void btnResetTracking_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.ResetTracking();
                Refresh();
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        void btnRefresh_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.Refresh();
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        void btnDebug_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.DumpState();
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        void btnHelp_Hit(object sender, EventArgs e)
        {
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;

                Globals.WriteToChat($"VERSION    : {version}.", ChatColors.GREEN);
                Globals.WriteToChat($"CREATED BY : Ahric Virindi.", ChatColors.GREEN);
                Globals.WriteToChat($"SUPPORT    : Discord username - ahric", ChatColors.GREEN);
                Globals.WriteToChat($"REQUESTS   : Discord username - ahric", ChatColors.GREEN);
                Globals.WriteToChat($"NOTE       : Not everything works right. Not everything is complete. Most annoyingly - because of the way floating point arithmetic works, not all calculations are exact.  Consider all calculated numbers over 100,000,000 to be approximate.", ChatColors.GREEN);
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }
    }
}
