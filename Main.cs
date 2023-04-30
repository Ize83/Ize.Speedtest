using Speedtest_Plugin;
using Speedtest_Plugin.Actions;
using SpeedTestSharp.Client;
using SuchByte.MacroDeck.Plugins;
using System.Collections.Generic;

namespace Ize.Speedtest_Plugin
{
    public class SpeedtestPlugin : MacroDeckPlugin
    {
        internal static MacroDeckPlugin Instance { get; set; }

        internal static ISpeedTestClient SpeedTestClient { get; } = new SpeedTestClient();

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

            SpeedTestClient.ProgressChanged += SpeedTestClient_ProgressChanged;
        }

        private void SpeedTestClient_ProgressChanged(object sender, SpeedTestSharp.DataTypes.External.ProgressInfo e)
        {
            switch (SpeedTestClient.CurrentStage)
            {
                case SpeedTestSharp.Enums.TestStage.Download:
                    VariableHelper.UpdateDownloadSpeed(e.Speed, SpeedTestClient.SpeedUnit.ToString());
                    break;
                case SpeedTestSharp.Enums.TestStage.Upload:
                    VariableHelper.UpdateUploadSpeed(e.Speed, SpeedTestClient.SpeedUnit.ToString());
                    break;
            }
        }
    }
}
