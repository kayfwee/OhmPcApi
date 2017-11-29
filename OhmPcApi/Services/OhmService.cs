using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using OhmPcApi.Models;

namespace OhmPcApi.Services
{
    public class OhmService
    {
        private Computer computer;

        public OhmService()
        {
            try
            {
                computer = new Computer();
                computer.CPUEnabled = true;
                computer.MainboardEnabled = true;
                computer.GPUEnabled = true;
                computer.RAMEnabled = true;
                computer.Open();
            }
            catch (Exception ex)
            {
                LogService.Log("OHM service initilisation failed.");
                LogService.Log(ex);
            }
        }

        public SystemStatus GetUpdatedSystemStatus()
        {
            SystemStatus status = new SystemStatus();

            try
            {
                status.Cpu = GetCpuStatuses(computer.Hardware.Where(x => x.HardwareType == HardwareType.CPU).FirstOrDefault());
                status.Gpu = GetGpuStatuses(computer.Hardware.Where(x => x.HardwareType == HardwareType.GpuNvidia).FirstOrDefault());
            }
            catch (Exception ex)
            {
                LogService.Log("Failed to obtain updated system status.");
                LogService.Log(ex);
            }

            return status;
        }

        private CpuStatus GetCpuStatuses(IHardware cpu)
        {
            CpuStatus status = new CpuStatus();
            if (cpu == null) return status;

            status.Name = cpu.Name;
            foreach (var sensor in cpu.Sensors.Where(x => x.SensorType == SensorType.Temperature))
            {
                status.Temperatures.Add(sensor.Value.HasValue ? sensor.Value.Value.ToString("0.00") : null);
            }
            foreach (var sensor in cpu.Sensors.Where(x => x.SensorType == SensorType.Clock && x.Name.StartsWith("CPU Core")))
            {
                status.Frequencies.Add(sensor.Value.HasValue ? sensor.Value.Value.ToString("0.00") : null);
            }
            return status;
        }

        private GpuStatus GetGpuStatuses(IHardware gpu)
        {
            GpuStatus status = new GpuStatus();
            if (gpu == null) return status;

            var tempSensor = gpu.Sensors.Where(x => x.SensorType == SensorType.Temperature).FirstOrDefault();
            var coreFrequencySensor = gpu.Sensors.Where(x => x.SensorType == SensorType.Clock && x.Name == "GPU Core").FirstOrDefault();
            var memFrequencySensor = gpu.Sensors.Where(x => x.SensorType == SensorType.Clock && x.Name == "GPU Memory").FirstOrDefault();
            status.Name = gpu.Name;
            status.Temperature = tempSensor != null ? (tempSensor.Value.HasValue ? tempSensor.Value.Value.ToString("0.00") : null) : null;
            status.CoreFrequency = coreFrequencySensor != null ? (coreFrequencySensor.Value.HasValue ? coreFrequencySensor.Value.Value.ToString("0.00") : null) : null;
            status.MemFrequency = memFrequencySensor != null ? (memFrequencySensor.Value.HasValue ? memFrequencySensor.Value.Value.ToString("0.00") : null) : null;
            return status;
        }
    }
}
