using System;
using System.Collections.Generic;
using System.Text;
using CMouss.Binance;

namespace CMouss.Binance.Tests
{
    public static class Config
    {
        public static string ApiKey = "x3X0Zx0XF8dgT736vT5qLE36Zu5Tp7x5NHnLEe2rrKKh0EMrNhFUNS8mQOgqqTWS";
        public static string ApiSecret = "EBA4JyZREOTDczPIpvHxS0uq49fgS4Ocs1WEQKSdoVWaJoOfYj5fqW2cE3qWCgDS";

        public static string SymbolTest = "COTIUSDT";
        public static string SymbolTestBuyPrice = "2.2175";
        public static string SymbolTestSellPrice = "100";

        public static string SymbolTestBuyQuantity = "100";
        public static string SymbolTestSellQuantity = "99";

        public static BinanceConfig GetConfig()
        {
            return new BinanceConfig
            {
                BaseURL = "https://api.binance.com/"
                ,
                UserAPIKey = ApiKey
                ,
                UserAPISecret = ApiSecret
            };

        }
    }
}
