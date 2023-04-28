using Ize.Speedtest_Plugin;
using SuchByte.MacroDeck.Logging;
using System;
using System.Threading.Tasks;
using SpeedTestSharp.Enums;

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
                var result = await SpeedtestPlugin.SpeedTestClient.TestSpeedAsync(SpeedUnit.Mbps);
                VariableHelper.UpdateLatency(result.Latency);
                VariableHelper.UpdateDownloadSpeed(result.DownloadSpeed, result.SpeedUnit.ToString());
                VariableHelper.UpdateUploadSpeed(result.UploadSpeed, result.SpeedUnit.ToString());
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(SpeedtestPlugin.Instance, ex.Message);
            }
            finally
            {
                _speedTestRunning = false;
                VariableHelper.UpdateState(false);
            }
        }
    }
}
