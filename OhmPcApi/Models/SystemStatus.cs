using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmPcApi.Models
{
    public class SystemStatus
    {
        public CpuStatus Cpu { get; set; }
        public GpuStatus Gpu { get; set; }
    }
}
