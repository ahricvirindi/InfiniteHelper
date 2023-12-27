using InfiniteHelper.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfiniteHelper.Views
{
    public class RetailAugmentationsView
    {
        private MyClasses.MetaViewWrappers.IStaticText lblRetailAugmentationsMessage;

        private MyClasses.MetaViewWrappers.IStaticText lblMightAug;
        private MyClasses.MetaViewWrappers.IStaticText lblShadowAug;
        private MyClasses.MetaViewWrappers.IStaticText lblClutchAug;
        private MyClasses.MetaViewWrappers.IStaticText lblEnduringAug;
        private MyClasses.MetaViewWrappers.IStaticText lblLearnerAug;

        private bool HasShutdown { get; set; } = false;


        public void Refresh()
        {
            if (HasShutdown) return;

            lblMightAug.Text = $"{Globals.Player.XP.Augs.MightOfTheSeventhMule:n0}";
            lblMightAug.TextColor = Globals.Player.XP.Augs.MightOfTheSeventhMule == 0 ? System.Drawing.Color.Red : System.Drawing.Color.White;
            lblShadowAug.Text = $"{Globals.Player.XP.Augs.ShadowOfTheSeventhMule:n0}";
            lblShadowAug.TextColor = Globals.Player.XP.Augs.ShadowOfTheSeventhMule == 0 ? System.Drawing.Color.Red : System.Drawing.Color.White;
            lblClutchAug.Text = $"{Globals.Player.XP.Augs.ClutchOfTheMiser:n0}";
            lblClutchAug.TextColor = Globals.Player.XP.Augs.ClutchOfTheMiser == 0 ? System.Drawing.Color.Red : System.Drawing.Color.White;
            lblEnduringAug.Text = $"{Globals.Player.XP.Augs.EnduringEnchantment:n0}";
            lblEnduringAug.TextColor = Globals.Player.XP.Augs.EnduringEnchantment == 0 ? System.Drawing.Color.Red : System.Drawing.Color.White;
            lblLearnerAug.Text = $"{Globals.Player.XP.Augs.QuickLearner:n0}";
            lblLearnerAug.TextColor = Globals.Player.XP.Augs.QuickLearner == 0 ? System.Drawing.Color.Red : System.Drawing.Color.White;
        }

        public void Init()
        {
            lblRetailAugmentationsMessage = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblRetailAugmentationsMessage");

            lblMightAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblMightAug");
            lblShadowAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblShadowAug");
            lblClutchAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblClutchAug");
            lblEnduringAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblEnduringAug");
            lblLearnerAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblLearnerAug");
        }


        public void Shutdown()
        {
            HasShutdown = true;

            lblRetailAugmentationsMessage = null;

            lblMightAug = null;
            lblShadowAug = null;
            lblClutchAug = null;
            lblEnduringAug = null;
            lblLearnerAug = null;
        }

        public void Disable(string message)
        {
            lblRetailAugmentationsMessage.Text = message;
        }
    }
}
