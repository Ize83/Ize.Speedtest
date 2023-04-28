using Ize.Speedtest_Plugin;
using SuchByte.MacroDeck.Variables;

namespace Speedtest_Plugin
{
    public static class VariableHelper
    {
        public static void UpdateLatency(double speed)
        {
            VariableManager.SetValue("SpeedtestLatency", speed, VariableType.Float, SpeedtestPlugin.Instance, null);
            VariableManager.SetValue("SpeedtestLatencyUnit", "ms", VariableType.String, SpeedtestPlugin.Instance, null);
        }

        public static void UpdateDownloadSpeed(double speed, string unit)
        {
            VariableManager.SetValue("SpeedtestDownload", speed, VariableType.Float, SpeedtestPlugin.Instance, null);
            VariableManager.SetValue("SpeedtestDownloadUnit", unit, VariableType.String, SpeedtestPlugin.Instance, null);
        }

        public static void UpdateUploadSpeed(double speed, string unit)
        {
            VariableManager.SetValue("SpeedtestUpload", speed, VariableType.Float, SpeedtestPlugin.Instance, null);
            VariableManager.SetValue("SpeedtestUploadUnit", unit, VariableType.String, SpeedtestPlugin.Instance, null);
        }

        public static void UpdateState(bool active)
        {
            VariableManager.SetValue("SpeedtestActive", active, VariableType.Bool, SpeedtestPlugin.Instance, null);
        }
    }
}
