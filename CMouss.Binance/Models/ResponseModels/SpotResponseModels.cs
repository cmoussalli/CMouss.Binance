using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CMouss.Binance.SpotResponseModels;

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




        #region Dust Models
        public class DustEligableAssets
        {
            public DustEligableAssets_Detail[] details { get; set; }
            public string totalTransferBtc { get; set; }
            public string totalTransferBNB { get; set; }
            public string dribbletPercentage { get; set; }
        }

        public class DustEligableAssets_Detail
        {
            public string asset { get; set; }
            public string assetFullName { get; set; }
            public string amountFree { get; set; }
            public string toBTC { get; set; }
            public string toBNB { get; set; }
            public string toBNBOffExchange { get; set; }
            public string exchange { get; set; }
        }


        #endregion


    }
}
