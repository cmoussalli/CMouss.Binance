using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binance
{
    public enum Interval
    {
        Minute_1 = 101,
        Minute_3 = 103,
        Minute_5 = 105,
        //Minute_15 = 115,
        Minute_30 = 130,

        Hour_1 = 201,
        Hour_2 = 202,
        Hour_4 = 204,

        Day_1 = 301,

        Week_1 = 401,

        Month_1 = 501
    }
}
