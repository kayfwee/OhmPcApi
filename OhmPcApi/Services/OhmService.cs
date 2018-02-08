using System;
using System.Linq;
using OpenHardwareMonitor.Hardware;
using OhmPcApi.Models;
using OhwPcApi.Common;

namespace OhmPcApi.Services
{
    public static class OhmService
    {
        private static Computer computer;
        private static UpdateVisitor visitor;

        public static void Initialise()
        {
            try
            {
                visitor = new UpdateVisitor();
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

        private static void Refresh()
        {
            computer.Accept(visitor);
        }

        public static SystemStatus GetUpdatedSystemStatus()
        {
            Refresh();
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

        private static CpuStatus GetCpuStatuses(IHardware cpu)
        {
            Refresh();
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

        private static GpuStatus GetGpuStatuses(IHardware gpu)
        {
            Refresh();
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
