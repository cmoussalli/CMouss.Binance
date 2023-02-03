using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Binance
{

    public class MarketServices
    {
        #region Props
        BinanceConfig _config = new BinanceConfig();
        public BinanceConfig Config { get { return _config; } }

        #endregion


        #region Constructor
        public MarketServices(BinanceConfig config)
        {
            _config = config;
        }
        #endregion

        public async Task<long> CheckServerTime()
        {
            MarketResponseModels.ServerTimeInfo res = new MarketResponseModels.ServerTimeInfo();
            HttpClient client = new HttpClient();
            string resStr = await client.GetStringAsync(_config.BaseURL + "api/v3/time");
            res = JsonSerializer.Deserialize<MarketResponseModels.ServerTimeInfo>(resStr);
            return res.serverTime;

        }


        public async Task<MarketResponseModels.ExchangeInfo> GetExchangeInfoAsync()
        {
            MarketResponseModels.ExchangeInfo res = new MarketResponseModels.ExchangeInfo();
            HttpClient client = new HttpClient();
            string resStr = await client.GetStringAsync(_config.BaseURL + "api/v3/exchangeInfo");
            res = JsonSerializer.Deserialize<MarketResponseModels.ExchangeInfo>(resStr);
            return res;

        }

        public async Task<List<SymbolPrice>> GetPairsPricesAsync()
        {
            List<SymbolPrice> res = new List<SymbolPrice>();
            HttpClient client = new HttpClient();
            string resStr = await client.GetStringAsync(_config.BaseURL + "api/v3/ticker/price");
            res = JsonSerializer.Deserialize<List<SymbolPrice>>(resStr);
            return res;

        }


        #region Get CandlesData
        public async Task<List<Candle>> GetCandlesDataAsync(string symbol, Interval interval, int limit)
        {
            return await GetCandlesDataAsync(symbol, interval, limit, null, null);
        }
        public async Task<List<Candle>> GetCandlesDataAsync(string symbol, Interval interval, int limit,DateTime? startTime, DateTime? endTime)
        {
            List<Candle> result = new List<Candle>();
            HttpClient client = new HttpClient();
            string pars = $"symbol={symbol}&interval={Helpers.IntervalToString(interval)}&limit={limit}";
            if (startTime is not null) { pars = pars + "&startTime=" + Helpers.GetUnixTimeStamp((DateTime)startTime); }
            if (endTime is not null) { pars = pars + "&endTime=" + Helpers.GetUnixTimeStamp((DateTime)endTime); }
            string resStr = await client.GetStringAsync(_config.BaseURL + "api/v3/klines?" + pars);
            List<string> candleStrLst = resStr.Split("[").ToList();
            foreach (string s in candleStrLst)
            {
                if (s.Length > 10)
                {
                    result.Add(Helpers.ParseCandle(s));
                }
            }
            return result;
        }
        #endregion


    }


}
