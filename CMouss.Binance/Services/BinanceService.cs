using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMouss.Binance
{
    public class BinanceService
    {

        #region Props
        public BinanceConfig Config { get; set; }

        #endregion


        public class HTTPPostResponse
        {
            public System.Net.HttpStatusCode StatusCode;
            public object Content;
        }





        public async Task<HTTPPostResponse> HTTPJsonPostAsync(bool useAuthenticate, string url, string queryStringParams, object dataObject, Type responseDataType)
        {
            HTTPPostResponse result = new();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            string pars = "";
            pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            //TODO: Add queryStringParams
            if (!string.IsNullOrEmpty( queryStringParams))
            pars = pars + "&" + queryStringParams;

            //Add API Key and Signature
            if (useAuthenticate)
            {
                pars = pars + "&recvWindow=60000";
                pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);
                pars = "?" + pars;
            }

            //Parse dataObject to Json
            string data = "";
            if (dataObject is not null)
            {
                data = JsonSerializer.Serialize(dataObject);
            }

            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Config.BaseURL + url + pars, content);
            if (response.IsSuccessStatusCode)
            {
                result.StatusCode = response.StatusCode;

                string res = await response.Content.ReadAsStringAsync();
                Debug.WriteLine("Request successful");
                Debug.WriteLine("Response: " + res);

                result.Content = JsonSerializer.Deserialize(res, responseDataType, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                Debug.WriteLine($"Request failed: {response.StatusCode} : {response.Content.ReadAsStringAsync()}");
            }


            return result;

        }



    }
}
