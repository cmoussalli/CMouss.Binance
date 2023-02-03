using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance
{
    public class Candle
    {
        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }



        private long openTime_UnixTime;
        private DateTimeOffset openTime_DateTimeOffset;
        public long OpenTime_UnixTime
        {
            get { return openTime_UnixTime; }
            set
            {
                openTime_UnixTime = value;
                openTime_DateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(value);
            }
        }
        public DateTimeOffset OpenTime_DataTimeOffset
        {
            get { return openTime_DateTimeOffset; }
            set
            {
                openTime_DateTimeOffset = value;
                openTime_UnixTime = value.ToUnixTimeMilliseconds();
            }
        }



        private long closeTime_UnixTime;
        private DateTimeOffset closeTime_DateTimeOffset;
        public long CloseTime_UnixTime
        {
            get { return closeTime_UnixTime; }
            set
            {
                closeTime_UnixTime = value;
                closeTime_DateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(value);
            }
        }
        public DateTimeOffset CloseTime_DataTimeOffset
        {
            get { return closeTime_DateTimeOffset; }
            set
            {
                closeTime_DateTimeOffset = value;
                closeTime_UnixTime = value.ToUnixTimeMilliseconds();
            }
        }



    }
}
