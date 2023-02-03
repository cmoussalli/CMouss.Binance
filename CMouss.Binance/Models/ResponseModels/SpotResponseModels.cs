using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Binance
{
    public class SpotResponseModels
    {


        public class AccountInfo
        {
            public int makerCommission { get; set; }
            public int takerCommission { get; set; }
            public int buyerCommission { get; set; }
            public int sellerCommission { get; set; }
            public bool canTrade { get; set; }
            public bool canWithdraw { get; set; }
            public bool canDeposit { get; set; }
            public long updateTime { get; set; }
            public string accountType { get; set; }
            public Balance[] balances { get; set; }
            public string[] permissions { get; set; }
        }

      

        
    }
}
