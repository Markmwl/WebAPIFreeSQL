using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    [JsonObject]
    public class DataSourceProperty
    {
        [JsonProperty]
        public string url { get; set; }
        [JsonProperty]
        public string username { get; set; }
        [JsonProperty]
        public string password { get; set; }
    }
}
