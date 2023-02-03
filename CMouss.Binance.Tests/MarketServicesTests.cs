using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

using CMouss.Binance;

namespace CMouss.Binance.Tests
{
    [TestClass]
    public class MarketServicesTests
    {

        [TestMethod]
        public void GetServerTimeInfoAsync()
        {
            BinanceServices b = new BinanceServices();
            Task<long> res = b.MarketServices.CheckServerTime();
            res.Wait();
            Debug.WriteLine("-----------------------------------------");
            Debug.WriteLine( res.Result.ToString() +" : Binance Time");
            Debug.WriteLine(Helpers.GetUnixTimeStamp() + " : Dev Time");
            Assert.IsNotNull(res.Result > 1);

        }


        [TestMethod]
        public void GetExchangeInfoAsync()
        {
            BinanceServices b = new BinanceServices();
            Task<MarketResponseModels.ExchangeInfo> res = b.MarketServices.GetExchangeInfoAsync();
            res.Wait();
            Assert.IsTrue(res.Result.symbols.Count>0);
          
        }

        [TestMethod]
        public void GetPairsPricesAsync()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            Task<List<SymbolPrice>> res = b.MarketServices.GetPairsPricesAsync();
            res.Wait();
            Assert.IsTrue(res.Result.Count >0);

        }

        [TestMethod]
        public void GetCandlesDataAsync()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            Task<List<Candle>> t = b.MarketServices.GetCandlesDataAsync("BTCUSDT",Interval.Hour_1,30);
            t.Wait();
            Assert.IsNotNull(t.Result.Count>0);

            t= b.MarketServices.GetCandlesDataAsync("BTCUSDT", Interval.Day_1, 30,new DateTime(2021,10,1), new DateTime(2021, 10, 10));
            t.Wait();
            Assert.IsNotNull(t.Result.Count > 0);
        }



    }
}
