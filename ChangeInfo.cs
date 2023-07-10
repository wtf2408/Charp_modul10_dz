using System;
using System.Collections.Generic;

namespace Charp_modul10_dz
{
    class ChangeInfo
    {
        public DateTime LastChangeTime { get; set; }
        public WorkerPosition LastChangerName { get; set; }

        public Dictionary<string, string> ChangedData { get; set;}
    }
}
