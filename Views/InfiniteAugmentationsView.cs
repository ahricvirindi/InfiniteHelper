using InfiniteHelper.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfiniteHelper.Views
{
    public class InfiniteAugmentationsView
    {
        private MyClasses.MetaViewWrappers.IStaticText lblInfiniteAugmentationsMessage;

        private MyClasses.MetaViewWrappers.IStaticText lblSpellCompAug;
        private MyClasses.MetaViewWrappers.IStaticText lblMissileAug;
        private MyClasses.MetaViewWrappers.IStaticText lblSpellDurationAug;
        private MyClasses.MetaViewWrappers.IStaticText lblVitAug;
        private MyClasses.MetaViewWrappers.IStaticText lblPetAug;
        private MyClasses.MetaViewWrappers.IStaticText lblCritDamageAug;
        private MyClasses.MetaViewWrappers.IStaticText lblCritChanceAug;
        private MyClasses.MetaViewWrappers.IStaticText lblCreatureBuffAug;

        private MyClasses.MetaViewWrappers.IStaticText lblBankedLum;

        private MyClasses.MetaViewWrappers.IStaticText lblSpellCompAugCost;
        private MyClasses.MetaViewWrappers.IStaticText lblMissileAugCost;
        private MyClasses.MetaViewWrappers.IStaticText lblSpellDurationAugCost;
        private MyClasses.MetaViewWrappers.IStaticText lblVitAugCost;
        private MyClasses.MetaViewWrappers.IStaticText lblPetAugCost;
        private MyClasses.MetaViewWrappers.IStaticText lblCritDamageAugCost;
        private MyClasses.MetaViewWrappers.IStaticText lblCritChanceAugCost;
        private MyClasses.MetaViewWrappers.IStaticText lblCreatureBuffAugCost;

        private MyClasses.MetaViewWrappers.IButton btnInfiniteAugsRefresh;

        private bool HasShutdown { get; set; } = false;


        public void Refresh()
        {
            if (HasShutdown) return;

            lblSpellCompAug.Text = $"{Globals.Player.Lum.AdvancedAugs.SpellComponents.Value:n0}%";
            lblMissileAug.Text = $"{Globals.Player.Lum.AdvancedAugs.MissileConsumption.Value:n0}%";
            lblSpellDurationAug.Text = $"+{Globals.Player.Lum.AdvancedAugs.SpellDuration.Value:n0} (+{Globals.ToReadableDurationString((int)(90 * (1 + ((Globals.Player.Lum.AdvancedAugs.SpellDuration.Value ?? 0) * .2))))} w/ 8s)";
            lblVitAug.Text = $"{Globals.Player.Lum.AdvancedAugs.Vitality.Value:n0}";
            lblPetAug.Text = $"{Globals.Player.Lum.AdvancedAugs.CombatPetDamage.Value:n0} (+{((Globals.Player.Lum.AdvancedAugs.CombatPetDamage.Value ?? 0) * 10):n0}%)";
            lblCritDamageAug.Text = $"{((Globals.Player.Lum.AdvancedAugs.CriticalStrikeDamage.Value ?? 0) / 10.0):n1}%";
            lblCritChanceAug.Text = $"{((Globals.Player.Lum.AdvancedAugs.CriticalStrikeChance.Value ?? 0) / 10.0):n1}%";
            lblCreatureBuffAug.Text = $"{Globals.Player.Lum.AdvancedAugs.CreatureBuffValue.Value:n0}";

            lblSpellCompAugCost.Text = $"{Globals.Player.Lum.AdvancedAugs.SpellComponents.RaiseCost:n0}";
            lblSpellCompAugCost.TextColor = Globals.Player.Lum.AdvancedAugs.SpellComponents.RaiseCost < Globals.Player.Bank.Luminance ? System.Drawing.Color.Green : System.Drawing.Color.White;
            lblMissileAugCost.Text = $"{Globals.Player.Lum.AdvancedAugs.MissileConsumption.RaiseCost:n0}";
            lblMissileAugCost.TextColor = Globals.Player.Lum.AdvancedAugs.MissileConsumption.RaiseCost < Globals.Player.Bank.Luminance ? System.Drawing.Color.Green : System.Drawing.Color.White;
            lblSpellDurationAugCost.Text = $"{Globals.Player.Lum.AdvancedAugs.SpellDuration.RaiseCost:n0}";
            lblSpellDurationAugCost.TextColor = Globals.Player.Lum.AdvancedAugs.SpellDuration.RaiseCost < Globals.Player.Bank.Luminance ? System.Drawing.Color.Green : System.Drawing.Color.White;
            lblVitAugCost.Text = $"{Globals.Player.Lum.AdvancedAugs.Vitality.RaiseCost:n0}";
            lblVitAugCost.TextColor = Globals.Player.Lum.AdvancedAugs.Vitality.RaiseCost < Globals.Player.Bank.Luminance ? System.Drawing.Color.Green : System.Drawing.Color.White;
            lblPetAugCost.Text = $"{Globals.Player.Lum.AdvancedAugs.CombatPetDamage.RaiseCost:n0}";
            lblPetAugCost.TextColor = Globals.Player.Lum.AdvancedAugs.CombatPetDamage.RaiseCost < Globals.Player.Bank.Luminance ? System.Drawing.Color.Green : System.Drawing.Color.White;
            lblCritDamageAugCost.Text = $"{Globals.Player.Lum.AdvancedAugs.CriticalStrikeDamage.RaiseCost:n0}";
            lblCritDamageAugCost.TextColor = Globals.Player.Lum.AdvancedAugs.CriticalStrikeDamage.RaiseCost < Globals.Player.Bank.Luminance ? System.Drawing.Color.Green : System.Drawing.Color.White;
            lblCritChanceAugCost.Text = $"{Globals.Player.Lum.AdvancedAugs.CriticalStrikeChance.RaiseCost:n0}";
            lblCritChanceAugCost.TextColor = Globals.Player.Lum.AdvancedAugs.CriticalStrikeChance.RaiseCost < Globals.Player.Bank.Luminance ? System.Drawing.Color.Green : System.Drawing.Color.White;
            lblCreatureBuffAugCost.Text = $"{Globals.Player.Lum.AdvancedAugs.CreatureBuffValue.RaiseCost:n0}";
            lblCreatureBuffAugCost.TextColor = Globals.Player.Lum.AdvancedAugs.CreatureBuffValue.RaiseCost < Globals.Player.Bank.Luminance ? System.Drawing.Color.Green : System.Drawing.Color.White;

            lblBankedLum.Text = $"{Globals.Player.Bank.Luminance:n0}";
        }

        public void Init()
        {
            lblInfiniteAugmentationsMessage = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblInfiniteAugmentationsMessage");

            lblSpellCompAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblSpellCompAug");
            lblMissileAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblMissileAug");
            lblSpellDurationAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblSpellDurationAug");
            lblVitAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblVitAug");
            lblPetAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblPetAug");
            lblCritDamageAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblCritDamageAug");
            lblCritChanceAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblCritChanceAug");
            lblCreatureBuffAug = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblCreatureBuffAug");
            lblSpellCompAugCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblSpellCompAugCost");
            lblMissileAugCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblMissileAugCost");
            lblSpellDurationAugCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblSpellDurationAugCost");
            lblVitAugCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblVitAugCost");
            lblPetAugCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblPetAugCost");
            lblCritDamageAugCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblCritDamageAugCost");
            lblCritChanceAugCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblCritChanceAugCost");
            lblCreatureBuffAugCost = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblCreatureBuffAugCost");

            lblBankedLum = (MyClasses.MetaViewWrappers.IStaticText)Globals.UI.GetViewControl("lblBankedLum");

            btnInfiniteAugsRefresh = (MyClasses.MetaViewWrappers.IButton)Globals.UI.GetViewControl("btnInfiniteAugsRefresh");

            btnInfiniteAugsRefresh.Hit += new EventHandler(btnInfiniteAugsRefresh_Hit);
        }


        public void Shutdown()
        {
            HasShutdown = true;

            lblInfiniteAugmentationsMessage = null;

            lblSpellCompAug = null;
            lblMissileAug = null;
            lblSpellDurationAug = null;
            lblVitAug = null;
            lblPetAug = null;
            lblCritDamageAug = null;
            lblCritChanceAug = null;
            lblCreatureBuffAug = null;

            lblSpellCompAugCost = null;
            lblMissileAugCost = null;
            lblSpellDurationAugCost = null;
            lblVitAugCost = null;
            lblPetAugCost = null;
            lblCritDamageAugCost = null;
            lblCritChanceAugCost = null;
            lblCreatureBuffAugCost = null;

            lblBankedLum = null;

            btnInfiniteAugsRefresh.Hit -= new EventHandler(btnInfiniteAugsRefresh_Hit);

            btnInfiniteAugsRefresh = null;
        }

        private void btnInfiniteAugsRefresh_Hit(object sender, EventArgs e)
        {
            if (!Globals.Allowed)
            {
                return;
            }

            try
            {
                Globals.SendCommand("/augs");
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        public void Disable(string message)
        {
            lblInfiniteAugmentationsMessage.Text = message;
        }
    }
}
