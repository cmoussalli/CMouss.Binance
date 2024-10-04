using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static CMouss.Binance.WalletResponseModels;


namespace CMouss.Binance
{

    public class WalletServices : BinanceService
    {





        #region Constructor
        public WalletServices(BinanceConfig config)
        {
            Config = config;
        }
        #endregion



        #region Dust
        public async Task<WalletResponseModels.GetDustEligableAssets> GetDustBalancesAsync()
        {
            //WalletResponseModels.DustEligableAssets res = new();
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            //string pars = "";
            //pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            ////if (symbol != null) { pars = pars + "&symbol=" + symbol; }
            //pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);
            //var httpResp = await client.PostAsync(Config.BaseURL + "sapi/v1/asset/dust-btc?" + pars, null);
            //if (!httpResp.IsSuccessStatusCode)
            //{
            //    Debug.WriteLine(httpResp.StatusCode + " - " + httpResp.Content.ReadAsStringAsync());
            //    throw new Exception(await httpResp.Content.ReadAsStringAsync());
            //}
            //string resStr = await httpResp.Content.ReadAsStringAsync();

            //res = JsonSerializer.Deserialize<WalletResponseModels.DustEligableAssets>(resStr);
            //return res;

            HTTPPostResponse response = await HTTPJsonPostAsync(true, "sapi/v1/asset/dust-btc", null, null, typeof(WalletResponseModels.GetDustEligableAssets));
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Error: " + response.StatusCode.ToString());
            }

            return (WalletResponseModels.GetDustEligableAssets)response.Content;
        }



        public async Task<ConvertDustToBNB> ConvertDustToBNBAsync(AccountType accountType, List<string> assets)
        {
            if (assets is null) { throw new ArgumentNullException("assets"); }
            if (assets.Count == 0) { throw new ArgumentException("assets cannot be empty"); }
            string paramsStr = "accountType=";
            switch (accountType)
            {
                case AccountType.SPOT:
                    paramsStr = paramsStr + "SPOT";
                    break;
                case AccountType.MARGIN:
                    paramsStr = paramsStr + "MARGIN";
                    break;
            }



            paramsStr = paramsStr + "&asset=";
            foreach (string a in assets)
            {
                paramsStr = paramsStr + a + ",";
            }
            paramsStr = paramsStr.Substring(0, paramsStr.Length - 1);

            HTTPPostResponse response = await HTTPJsonPostAsync(true, "sapi/v1/asset/dust", paramsStr, null, typeof(WalletResponseModels.ConvertDustToBNB));
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Error: " + response.StatusCode.ToString());
            }

            return (WalletResponseModels.ConvertDustToBNB)response.Content;
        }



        #endregion



    }


}
