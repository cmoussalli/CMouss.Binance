//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;


//namespace CMouss.Binance
//{

//    public class WalletServices
//    {
//        #region Props
//        BinanceConfig _config = new BinanceConfig();
//        public BinanceConfig Config { get { return _config; } }

//        #endregion


//        #region Constructor
//        public WalletServices(BinanceConfig config)
//        {
//            _config = config;
//        }
//        #endregion




//        public async Task<WalletResponseModels.AccountSnapshot> GetDailySnapshot()
//        {
//            WalletResponseModels.AccountSnapshot res = new WalletResponseModels.AccountSnapshot();
//            HttpClient client = new HttpClient();
//            string resStr = await client.GetStringAsync(_config.BaseURL + "api/v3/exchangeInfo");
//            res = JsonSerializer.Deserialize<MarketResponseModels.ExchangeInfo>(resStr);
//            return res;

//        }

//        public async Task<List<SymbolPrice>> GetPairsPricesAsync()
//        {
//            List<SymbolPrice> res = new List<SymbolPrice>();
//            HttpClient client = new HttpClient();
//            string resStr = await client.GetStringAsync(_config.BaseURL + "api/v3/ticker/price");
//            res = JsonSerializer.Deserialize<List<SymbolPrice>>(resStr);
//            return res;

//        }

//    }


//}
