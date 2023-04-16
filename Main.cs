using Speedtest_Plugin;
using Speedtest_Plugin.Actions;
using SuchByte.MacroDeck.Plugins;
using System.Collections.Generic;

namespace Ize.Speedtest_Plugin
{
    public class SpeedtestPlugin : MacroDeckPlugin
    {
        internal static MacroDeckPlugin Instance { get; set; }

        public SpeedtestPlugin()
        {
            Instance = this;
        }

        public override void Enable()
        {
            this.Actions = new List<PluginAction>
            {
                new SpeedtestAction(),
            };

            VariableHelper.UpdateState(false);
            SpeedtestHelper.ExecuteSpeedTest();
        }
    }
}
