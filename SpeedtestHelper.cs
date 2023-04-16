using Ize.Speedtest_Plugin;
using SpeedTest.Net.Enums;
using SpeedTest.Net;
using SuchByte.MacroDeck.Logging;
using System;
using System.Threading.Tasks;

namespace Speedtest_Plugin
{
    public static class SpeedtestHelper
    {
        private static bool _speedTestRunning = false;

        public static void ExecuteSpeedTest()
        {
            Task.Run(async () => await ExecuteSpeedTestAsync());
        }

        private static async Task ExecuteSpeedTestAsync()
        {
            if (_speedTestRunning)
            {
                return;
            }

            _speedTestRunning = true;
            VariableHelper.UpdateState(true);

            try
            {
                var download = await FastClient.GetDownloadSpeed(SpeedTestUnit.MegaBitsPerSecond);
                VariableHelper.UpdateDownloadSpeed(download.Speed, download.Unit);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(SpeedtestPlugin.Instance, ex.StackTrace);
            }
            finally
            {
                _speedTestRunning = false;
                VariableHelper.UpdateState(false);
            }
        }
    }
}
