using SuchByte.MacroDeck;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using System;
using System.Collections.Generic;
using System.Drawing;
using SpeedTest.Net.Enums;
using SpeedTest.Net.Models;
using SpeedTest.Net;

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
                new Speedtest(),
            };
        }
    }

    public class Speedtest : PluginAction
    {
        public override string Name => "Speedtest";
        public override string Description => "Runs a speedtest and updates the speedtest variables.";
        public override void Trigger(string clientId, ActionButton actionButton)
        {
            VariableManager.SetValue("SpeedtestActive", true, VariableType.Bool, SpeedtestPlugin.Instance, true);
            ExecuteSpeedTest();
        }

        private async void ExecuteSpeedTest()
        {
            try
            {
                DownloadSpeed speed = null;

                speed = await FastClient.GetDownloadSpeed(SpeedTestUnit.KiloBitsPerSecond);

                VariableManager.SetValue("SpeedtestDownload", speed.Speed, VariableType.Float, SpeedtestPlugin.Instance, true);
                VariableManager.SetValue("SpeedtestActive", false, VariableType.Bool, SpeedtestPlugin.Instance, true);

            }
            catch (System.Exception ex)
            {
                MacroDeckLogger.Error(SpeedtestPlugin.Instance, ex.Message);
            }
        }
    }



}
