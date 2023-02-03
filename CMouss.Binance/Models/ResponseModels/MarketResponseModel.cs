
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Binance
{
    public class MarketResponseModels
    {

        public class ServerTimeInfo
        {
            public long serverTime { get; set; }
        }


        public class ExchangeInfo
        {

            public string timezone { get; set; }
            public long serverTime { get; set; }
            public List<RateLimit> rateLimits { get; set; }
            public List<object> exchangeFilters { get; set; }
            public List<Symbol> symbols { get; set; }



        }

        



    }
}
