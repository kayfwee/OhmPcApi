using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmPcApi.Models
{
    public class CpuStatus
    {
        public CpuStatus()
        {
            Temperatures = new List<string>();
            Frequencies = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Temperatures { get; set; }
        public List<string> Frequencies { get; set; }
        public List<string> Load { get; set; }
    }
}
