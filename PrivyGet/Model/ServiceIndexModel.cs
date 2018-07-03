using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivyGet.Model
{
    public class ServiceIndexModel
    {
        public string version { get; set; }

        public IEnumerable<Resources> Resources { get; set; }
    }
}
