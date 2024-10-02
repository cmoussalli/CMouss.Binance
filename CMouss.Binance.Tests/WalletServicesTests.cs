using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using CMouss.Binance;

namespace CMouss.Binance.Tests
{
    [TestClass]
    public class WalletServicesTests
    {

      
        #region Get Eligible Dust Assets
        [TestMethod]
        public void GetEligibleDustAssetsAsync()
        {
            BinanceServices b = new BinanceServices(Config.GetConfig());
            var task = Task.Run(async () => await b.WalletServices.GetDustBalancesAsync());
            var result = task.Result;
            Assert.IsTrue(decimal.Parse( result.totalTransferBNB) > 0);
        }
        #endregion



    }
}
