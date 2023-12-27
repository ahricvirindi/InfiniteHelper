using Decal.Adapter;
using InfiniteHelper.Global;
using System;


namespace InfiniteHelper
{
    [FriendlyName("InfiniteHelper")]
    public partial class PluginCore : PluginBase
    {
        protected override void Startup()
        {
            try
            {
                Globals.LogFilePath = Path + "\\InfiniteHelper.log";
                
                Globals.Path = Path;
                Globals.Core = Core;
                Globals.Host = Host;
                Globals.Events.Init();
                
                // make sure this is last
                Globals.StartHeartbeat();
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }

        protected override void Shutdown()
        {
            try
            {
                Globals.Events.Shutdown();
                Globals.UI.Shutdown();
            }
            catch (Exception ex)
            {
                Globals.Log(ex);
            }
        }
    }
}