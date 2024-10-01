using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using CMouss.Binance;

namespace CMouss.Binance.Tests
{
    [TestClass]
    public class SpotServicesTests
    {

        #region Get Account Info
        [TestMethod]
        public void GetAccountInfoAsync()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.GetAccountInfoAsync());
            var result = task.Result;
            Assert.IsTrue(result.balances.Length > 0);
        }
        #endregion

        #region Get Eligible Dust Assets
        [TestMethod]
        public void GetEligibleDustAssetsAsync()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.GetDustEligableAssetsAsync());
            var result = task.Result;
            Assert.IsTrue(decimal.Parse( result.totalTransferBNB) > 0);
        }
        #endregion



        #region Get Open Orders
        [TestMethod]
        public void GetOpenOrdersAsync_All()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.GetOpenOrdersAsync());
            var result = task.Result;
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetOpenOrdersAsync_BySymbol()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.GetOpenOrdersAsync(Config.SymbolTest));
            var result = task.Result;
            //Assert.IsTrue(result.Count > 0);
        }
        #endregion

        #region Get Symbol Orders
        [TestMethod]
        public void GetSymbolOrdersAsync_BySymbol()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.GetSymbolOrdersAsync(Config.SymbolTest, 5000));
            var result = task.Result;
        }
        [TestMethod]
        public void GetSymbolOrdersAsync_Last24Hours()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.GetSymbolOrdersAsync(Config.SymbolTest,5000,(DateTime) DateTime.UtcNow.AddHours(-24),(DateTime)DateTime.UtcNow));
            var result = task.Result;
        }
        [TestMethod]
        public void GetSymbolOrdersAsync_StartFromOrderId()
        {
            long orderId = 0;
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.GetSymbolOrdersAsync(Config.SymbolTest, 5000, orderId));
            var result = task.Result;
        }
        #endregion


        #region Cancel Symbol Orders
        [TestMethod]
        public void CancelSymbolOpenOrders()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.CancelSymbolOpenOrdersAsync(Config.SymbolTest));
            var result = task.Result;
        }

        #endregion


        #region New Orders - Limit
        [TestMethod]

        public void NewOrder_BuyLimit()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.NewOrder_BuyLimit(Config.SymbolTest, "GTC", decimal.Parse( "22"), decimal.Parse(Config.SymbolTestBuyPrice)));
            var result = task.Result;
        }

        [TestMethod]
        public void NewOrder_SellLimit()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.NewOrder_SellLimit(Config.SymbolTest,"GTC",1,decimal.Parse(Config.SymbolTestSellPrice)));
            var result = task.Result;
        }

        #endregion


        #region New Orders - Market
        [TestMethod]

        public void NewOrder_BuyMarket()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.NewOrder_BuyMarket(Config.SymbolTest, decimal.Parse(Config.SymbolTestBuyQuantity)));
            var result = task.Result;
        }

        [TestMethod]
        public void NewOrder_SellMarket()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.SpotServices.NewOrder_SellMarket(Config.SymbolTest, decimal.Parse(Config.SymbolTestSellQuantity)));
            var result = task.Result;
        }

        #endregion


        //[TestMethod]
        //public void NewOCO_Sell()
        //{
        //    BinanceServices b = new BinanceServices(Config.GetConfig());
        //    var task = Task.Run(async () => await b.SpotServices.NewOCO_Sell("TKOUSDT", 9.3m, 2.755m,2.568m));
        //    var result = task.Result;
        //}
    }
}
