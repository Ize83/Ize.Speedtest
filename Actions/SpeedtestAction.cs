using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;

namespace Speedtest_Plugin.Actions
{
    public class SpeedtestAction : PluginAction
    {
        public override string Name => "Speedtest";

        public override string Description => "Runs a speedtest and updates the speedtest variables.";

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            SpeedtestHelper.ExecuteSpeedTest();
        }
    }
}
