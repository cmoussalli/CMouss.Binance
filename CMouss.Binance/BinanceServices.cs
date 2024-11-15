﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Binance
{

    public class BinanceConfig
    {
        public string UserAPIKey { get; set; }
        public string UserAPISecret { get; set; }
        public string BaseURL { get; set; }
    }

    public class BinanceServices
    {
        BinanceConfig _config = new BinanceConfig();
        public BinanceConfig Config { get { return _config; } }





        #region Constructor
        public BinanceServices()
        {
            Init(new BinanceConfig { BaseURL = "https://api.binance.com/" });
        }
        public BinanceServices(BinanceConfig config)
        {
            Init(config);
        }

        


        #endregion

        private void Init(BinanceConfig config)
        {
            _config = config;
            walletServices = new WalletServices(config);
            marketServices = new MarketServices(config);
            spotServices = new SpotServices(config);
        }


        WalletServices walletServices; public WalletServices WalletServices { get { return walletServices; } }
        MarketServices marketServices; public MarketServices MarketServices { get { return marketServices; } }
        SpotServices spotServices; public SpotServices SpotServices { get { return spotServices; } }
    }
}
