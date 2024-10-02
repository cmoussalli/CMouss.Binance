using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Binance
{
    public class BinanceService
    {

        #region Props
        public BinanceConfig Config { get; set; } 

        #endregion






        public async Task<HttpClient> GetHttpClient(string url, string userAPIKey, string userApiSecret )
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            string pars = "";
            pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            //if (symbol != null) { pars = pars + "&symbol=" + symbol; }

            pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);
            var httpResp = await client.PostAsync(Config.BaseURL + "sapi/v1/asset/dust-btc?" + pars, null);
            if (!httpResp.IsSuccessStatusCode)
            {
                Debug.WriteLine(httpResp.StatusCode + " - " + httpResp.Content.ReadAsStringAsync());
                throw new Exception(await httpResp.Content.ReadAsStringAsync());
            }
            string resStr = await httpResp.Content.ReadAsStringAsync();


        }



    }
}
