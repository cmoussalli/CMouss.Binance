﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace CMouss.Binance
{

    public class WalletServices
    {
        #region Props
        BinanceConfig _config = new BinanceConfig();
        public BinanceConfig Config { get { return _config; } }

        #endregion


        #region Constructor
        public WalletServices(BinanceConfig config)
        {
            _config = config;
        }
        #endregion



        #region Dust
        public async Task<WalletResponseModels.DustEligableAssets> GetDustBalancesAsync()
        {
            WalletResponseModels.DustEligableAssets res = new();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            string pars = "";
            pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            //if (symbol != null) { pars = pars + "&symbol=" + symbol; }
            pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);
            var httpResp = await client.PostAsync(_config.BaseURL + "sapi/v1/asset/dust-btc?" + pars, null);
            if (!httpResp.IsSuccessStatusCode)
            {
                Debug.WriteLine(httpResp.StatusCode + " - " + httpResp.Content.ReadAsStringAsync());
                throw new Exception(await httpResp.Content.ReadAsStringAsync());
            }
            string resStr = await httpResp.Content.ReadAsStringAsync();

            res = JsonSerializer.Deserialize<WalletResponseModels.DustEligableAssets>(resStr);
            return res;

        }



        #endregion



    }


}
