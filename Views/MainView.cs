using InfiniteHelper.Global;
using MyClasses.MetaViewWrappers;
using System;
using System.Drawing;

namespace InfiniteHelper.Views
{
    public class MainView
    {
        private MyClasses.MetaViewWrappers.IView view;
        private TrackingView trackingView;
        private BankView bankView;
        private AttributesView attributesView;
        private RetailAugmentationsView retailAugmentationsView;
        private InfiniteAugmentationsView infiniteAugmentationsView;
        private TravelView travelView;


        public void Init()
        {
            try
            {
                view = MyClasses.MetaViewWrappers.ViewSystemSelector.CreateViewResource(Globals.Host, "InfiniteHelper.Views.MainView.xml");
                trackingView = new TrackingView();
                bankView = new BankView();
                attributesView = new AttributesView();
                retailAugmentationsView = new RetailAugmentationsView();
                infiniteAugmentationsView = new InfiniteAugmentationsView();
                travelView = new TravelView();
                
                trackingView.Init();
                bankView.Init();
                attributesView.Init();
                retailAugmentationsView.Init();
                infiniteAugmentationsView.Init();
                travelView.Init();
            } catch(Exception ex) {
                Globals.WriteToChat(ex.StackTrace);
                Globals.Log(ex);
            }
        }

        public object GetViewControl(string controlId)
        {
            return view[controlId];
        }

        public void Refresh()
        {
            if (!Globals.Allowed)
            {
                Disable();
                return;
            }

            trackingView.Refresh();
            bankView.Refresh();
            attributesView.Refresh();
            retailAugmentationsView.Refresh();
            infiniteAugmentationsView.Refresh();
            travelView.Refresh();
        }

        public void Shutdown()
        {
            trackingView.Shutdown();
            bankView.Shutdown();
            attributesView.Shutdown();
            retailAugmentationsView.Shutdown();
            infiniteAugmentationsView.Shutdown();
            travelView.Shutdown();

            view.Dispose();
        }

        public void Disable()
        {
            var message = "Your account is not authorized to run this plugin on this server.";

            trackingView.Disable(message);
            bankView.Disable(message);
            attributesView.Disable(message);
            retailAugmentationsView.Disable(message);
            infiniteAugmentationsView.Disable(message);
            travelView.Disable(message);
        }
    }
}