using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;



namespace Binance
{

    public class SpotServices
    {
        #region Props
        BinanceConfig _config = new BinanceConfig();
        public BinanceConfig Config { get { return _config; } }

        #endregion

        #region Constructor
        public SpotServices(BinanceConfig config)
        {
            _config = config;
        }
        #endregion



        #region Get Account Info

        public async Task<SpotResponseModels.AccountInfo> GetAccountInfoAsync()
        {
            SpotResponseModels.AccountInfo res = new SpotResponseModels.AccountInfo();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            string pars = "";
            pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);
            string resStr = await client.GetStringAsync(_config.BaseURL + "api/v3/account?" + pars);
            res = JsonSerializer.Deserialize<SpotResponseModels.AccountInfo>(resStr);
            return res;

        }
        #endregion

        #region Get Open Orders
        public async Task<List<Order>> GetOpenOrdersAsync()
        {
            return await GetOpenOrdersAsync(null);
        }

        public async Task<List<Order>> GetOpenOrdersAsync(string? symbol)
        {
            List<Order> res = new List<Order>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            string pars = "";
            pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            if (symbol != null) { pars = pars + "&symbol=" + symbol; }
            pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);
            string resStr = await client.GetStringAsync(_config.BaseURL + "api/v3/openOrders?" + pars);
            res = JsonSerializer.Deserialize<List<Order>>(resStr);
            return res;

        }
        #endregion

        #region Get Symbol Orders
        public async Task<List<Order>> GetSymbolOrdersAsync(string symbol, int limit)
        {
            return await GetSymbolOrdersAsync(symbol, limit, null, null, null);
        }
        public async Task<List<Order>> GetSymbolOrdersAsync(string symbol, int limit, long startOrderId)
        {
            return await GetSymbolOrdersAsync(symbol, limit, startOrderId, null, null);
        }
        public async Task<List<Order>> GetSymbolOrdersAsync(string symbol, int limit, DateTime utcStartTime, DateTime utcEndTime)
        {
            return await GetSymbolOrdersAsync(symbol, limit, null, utcStartTime, utcEndTime);
        }


        private async Task<List<Order>> GetSymbolOrdersAsync(string symbol, int limit, long? startOrderID, DateTime? utcStartTime, DateTime? utcEndTime)
        {
            List<Order> res = new List<Order>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            string pars = "";
            pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            pars = pars + "&limit=" + limit.ToString();
            if (startOrderID != null) { pars = pars + "&orderId=" + (long)startOrderID; }
            if (utcStartTime != null && utcEndTime != null) { pars = pars + "&startTime=" + Helpers.GetUnixTimeStamp((DateTime)utcStartTime) + "&endTime=" + Helpers.GetUnixTimeStamp((DateTime)utcEndTime); }
            if (symbol != null) { pars = pars + "&symbol=" + symbol; }
            pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);
            string resStr = await client.GetStringAsync(_config.BaseURL + "api/v3/allOrders?" + pars);
            res = JsonSerializer.Deserialize<List<Order>>(resStr);
            return res;
        }

        


        #endregion



        #region Get Trades
        public async Task<List<Trade>> GetSymbolTradesAsync(string symbol, int limit)
        {
            return await GetSymbolTradesAsync(symbol, limit, null, null, null);
        }
        public async Task<List<Trade>> GetSymbolTradesAsync(string symbol, int limit, long startTradeID)
        {
            return await GetSymbolTradesAsync(symbol, limit, startTradeID, null, null);
        }
        public async Task<List<Trade>> GetSymbolTradesAsync(string symbol, int limit, DateTime utcStartTime, DateTime utcEndTime)
        {
            return await GetSymbolTradesAsync(symbol, limit, null, utcStartTime, utcEndTime);
        }


        private async Task<List<Trade>> GetSymbolTradesAsync(string symbol, int limit, long? startTradeID, DateTime? utcStartTime, DateTime? utcEndTime)
        {
            List<Trade> res = new List<Trade>();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            string pars = "";
            pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            pars = pars + "&limit=" + limit.ToString();
            if (startTradeID != null) { pars = pars + "&fromId=" + (long)startTradeID; }
            if (symbol != null) { pars = pars + "&symbol=" + symbol; }
            if (utcStartTime != null && utcEndTime != null) { pars = pars + "&startTime=" + Helpers.GetUnixTimeStamp((DateTime)utcStartTime) + "&endTime=" + Helpers.GetUnixTimeStamp((DateTime)utcEndTime); }
            pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);
            string resStr = await client.GetStringAsync(_config.BaseURL + "api/v3/myTrades?" + pars);
            res = JsonSerializer.Deserialize<List<Trade>>(resStr);
            return res;
        }
        #endregion



        #region Cancel Open Orders
        public async Task<string> CancelOpenOrderAsync(string symbol, long orderId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            string pars = "";
            pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            if (symbol != null) { pars = pars + "&symbol=" + symbol; }
            if (orderId != null) { pars = pars + "&orderId=" + orderId; }
            pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);
            await client.DeleteAsync(_config.BaseURL + "api/v3/order?" + pars);
            return "Ok";
        }
        #endregion

        #region Cancel Symbol Open Orders
        public async Task<string> CancelSymbolOpenOrdersAsync(string symbol)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            string pars = "";
            pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            if (symbol != null) { pars = pars + "&symbol=" + symbol; }

            pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);
             await client.DeleteAsync(_config.BaseURL + "api/v3/openOrders?" + pars);
            return "Ok";
        }
        #endregion


        #region New Order

        #region Market
        public async Task<string> NewOrder_BuyMarket(string symbol, decimal? quantity)
        {
            return await NewOrder(symbol, "BUY", "MARKET", quantity, null, null, null);
        }
        public async Task<string> NewOrder_SellMarket(string symbol, decimal? quantity)
        {
            return await NewOrder(symbol, "SELL", "MARKET", quantity, null, null,null);
        }
        #endregion

        #region Limit
        public async Task<string> NewOrder_BuyLimit(string symbol, string timeInForce, decimal? quantity, decimal? price)
        {
            return await NewOrder(symbol, "BUY", "LIMIT", quantity, price, null, timeInForce);
        }
        public async Task<string> NewOrder_SellLimit(string symbol, string timeInForce, decimal? quantity, decimal? price)
        {
            return await NewOrder(symbol, "SELL", "LIMIT", quantity, price, null, timeInForce);
        }
        #endregion
        
        
        
        
        private async Task<string> NewOrder(string symbol, string side, string type,decimal? quantity, decimal? price,decimal? stopPrice,string timeInForce)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            string pars = "";
            pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            if (symbol != null) { pars = pars + "&symbol=" + symbol; }
            if (side != null) { pars = pars + "&side=" + side; }
            if (type != null) { pars = pars + "&type=" + type; }
            if (quantity != null) { pars = pars + "&quantity=" + quantity; }
            if (price != null) { pars = pars + "&price=" + price; }
            if (stopPrice != null) { pars = pars + "&stopPrice=" + stopPrice; }
            if (timeInForce != null) { pars = pars + "&timeInForce=" + timeInForce; }

            pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);

            var payload = "";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

            HttpResponseMessage res = await client.PostAsync(_config.BaseURL + "api/v3/order?" + pars,content);
            if (!res.IsSuccessStatusCode)
            {

                Debug.WriteLine(res.StatusCode + " - " + res.Content.ReadAsStringAsync());
                throw new Exception(await res.Content.ReadAsStringAsync());
            }
            return "Ok";
        }


        #endregion





        #region New OCO
        public async Task<string> NewOCO_Buy(string symbol, decimal quantity, decimal price, decimal stopPrice, decimal stopLimitPrice)
        {
            return await NewOCO(symbol, "BUY", quantity, price, stopPrice, stopLimitPrice);
        }
        public async Task<string> NewOCO_Sell(string symbol, decimal quantity, decimal price, decimal stopPrice,decimal stopLimitPrice)
        {
            return await NewOCO(symbol, "SELL", quantity, price, stopPrice, stopLimitPrice);
        }


        private async Task<string> NewOCO(string symbol, string side, decimal quantity, decimal price, decimal stopPrice, decimal stopLimitPrice)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Config.UserAPIKey);
            string pars = "";
            pars = pars + "timestamp=" + Helpers.GetUnixTimeStamp();
            if (symbol != null) { pars = pars + "&symbol=" + symbol; }
            if (side != null) { pars = pars + "&side=" + side; }
            if (quantity != null) { pars = pars + "&quantity=" + quantity; }
            if (price != null) { pars = pars + "&price=" + price; }
            if (stopPrice != null) { pars = pars + "&stopPrice=" + stopPrice; }
            if (stopLimitPrice != null) { pars = pars + "&stopLimitPrice=" + stopLimitPrice; }
            pars = pars + "&stopLimitTimeInForce=GTC";

            pars = pars + "&signature=" + Helpers.CreateSignature(pars, Config.UserAPISecret);

            var payload = "";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

            HttpResponseMessage res = await client.PostAsync(_config.BaseURL + "api/v3/order/oco?" + pars, content);
            if (!res.IsSuccessStatusCode)
            {

                Debug.WriteLine(res.StatusCode + " - " + res.Content.ReadAsStringAsync());
                throw new Exception(await res.Content.ReadAsStringAsync());
            }
            return "Ok";
        }
        #endregion
    }


}
