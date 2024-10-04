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

        #region BinanceMethod: Get Assets That Can Be Converted Into BNB (USER_DATA)
        public class GetDustEligableAssets
        {
            public GetDustEligableAssets_Detail[] details { get; set; }
            public string totalTransferBtc { get; set; }
            public string totalTransferBNB { get; set; }
            public string dribbletPercentage { get; set; }
        }

        public class GetDustEligableAssets_Detail
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

        #region BinanceMethod: Dust Transfer (USER_DATA)

        public class ConvertDustToBNB
        {
            public string totalServiceCharge { get; set; }
            public string totalTransfered { get; set; }
            public ConvertDustToBNB_TransferResult[] transferResult { get; set; }
        }

        public class ConvertDustToBNB_TransferResult
        {
            public string amount { get; set; }
            public string fromAsset { get; set; }
            public long operateTime { get; set; }
            public string serviceChargeAmount { get; set; }
            public long tranId { get; set; }
            public string transferedAmount { get; set; }
        }
        #endregion





        #endregion



    }
}
