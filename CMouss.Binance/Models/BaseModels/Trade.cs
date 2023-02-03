using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Binance
{
    public class Trade
    {

        public int id { get; set; }
        public long orderId { get; set; }
        public string symbol { get; set; }
        public int orderListId { get; set; }
        public string price { get; set; }
        public string qty { get; set; }
        public string quoteQty { get; set; }
        public string commission { get; set; }
        public string commissionAsset { get; set; }
        public long time { get; set; }
        public bool isBuyer { get; set; }
        public bool isMaker { get; set; }
        public bool isBestMatch { get; set; }

    }
}
