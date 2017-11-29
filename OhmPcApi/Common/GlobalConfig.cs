using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmPcApi.Common
{
    public class GlobalConfig
    {
        // Server Configs
        public string Port { get; set; }
        public string ManualIpOverride { get; set; }

        // CPU Configs
        public bool ShowCpu{ get; set; }
        public bool ShowCpuFrequency{ get; set; }
        public bool ShowCpuTemperature{ get; set; }
        public bool ShowCpuLoad{ get; set; }
        public bool AverageCpuTemperature{ get; set; }
        public bool AverageCpuFrequency{ get; set; }
        public bool AverageCpuLoad{ get; set; }

        // GPU Configs
        public bool ShowGpu{ get; set; }
        public bool ShowGpuCoreFrequency{ get; set; }
        public bool ShowGpuMemFrequency{ get; set; }
        public bool ShowGpuTemperature{ get; set; }
        public bool ShowGpuCoreLoad{ get; set; }
        public bool ShowGpuMemLoad{ get; set; }

        // RAM Configs
        public bool ShowRam{ get; set; }
        public bool ShowRamLoad{ get; set; }
        public bool ShowRamUsed{ get; set; }
        public bool ShowRamFree{ get; set; }

        // Misc Configs
        public string BackgroundPath{ get; set; }
        public string SpritePath{ get; set; }
    }
}
