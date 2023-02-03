using System;
using System.Collections.Generic;
using System.Text;
using CMouss.Binance;

namespace CMouss.Binance.Tests
{
    public static class Config
    {
        public static string ApiKey = "---";
        public static string ApiSecret = "---";

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
