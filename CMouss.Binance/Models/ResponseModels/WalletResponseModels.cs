using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Binance
{
    public class WalletResponseModels
    {

        public class AccountSnapshot
        {
            public int code { get; set; }
            public string msg { get; set; }
            public Snapshotvo[] snapshotVos { get; set; }
        }
       

      

       

    }
}
