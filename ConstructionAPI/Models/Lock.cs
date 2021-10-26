using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructionAPI.Models
{
    public class Lock
    {
        public string Type { get; set; }
        public int Qty { get; set; }
        public string Material { get; set; }

        public bool isLockComplete { get; set; }
    }
}
