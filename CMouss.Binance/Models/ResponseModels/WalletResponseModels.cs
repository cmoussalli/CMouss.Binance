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
