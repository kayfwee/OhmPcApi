using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmPcApi.Models
{
    public class GpuStatus
    {
        public string Name { get; set; }
        public string Temperature { get; set; }

        [JsonProperty("core_frequency")]
        public string CoreFrequency { get; set; }

        [JsonProperty("mem_frequency")]
        public string MemFrequency { get; set; }

        [JsonProperty("core_load")]
        public string CoreLoad { get; set; }

        [JsonProperty("mem_load")]
        public string MemLoad { get; set; }
    }
}
