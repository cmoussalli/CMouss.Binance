﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Binance
{
    public class Snapshotvo
    {
        public string type { get; set; }
        public long updateTime { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string totalAssetOfBtc { get; set; }
        public Balance[] balances { get; set; }
    }
}
