using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance
{
    public class Balance
    {
        public string asset { get; set; }
        public string free { get; set; }
        public string locked { get; set; }
    }
}
