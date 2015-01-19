using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JsonData
    {
        public string SiteId { get; set; }
        public string SiteName { get; set; }
        public string County { get; set; }
        public string Township { get; set; }
        public string TWD67Lon { get; set; }
        public string TWD67Lat { get; set; }
        public string Rainfall10min { get; set; }
        public string Rainfall1hr { get; set; }
        public string Rainfall3hr { get; set; }
        public string Rainfall6hr { get; set; }
        public string Rainfall12hr { get; set; }
        public string Rainfall24hr { get; set; }
        public string Now { get; set; }
        public string Unit { get; set; }
        public string PublishTime { get; set; }
    }
}
