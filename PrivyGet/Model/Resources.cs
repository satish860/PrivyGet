using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivyGet.Model
{
    public class Resources
    {
        [JsonProperty(PropertyName = "@id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "@type")]
        public string Type { get; set; }

        public string Comment { get; set; }
    }
}
