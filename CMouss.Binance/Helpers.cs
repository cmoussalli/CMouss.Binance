using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Binance
{
    public static class Helpers
    {

        public static string GetUnixTimeStamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        }

        public static string GetUnixTimeStamp(DateTime dateTime)
        {
            return ((DateTimeOffset)dateTime).ToUnixTimeMilliseconds().ToString();
        }


        public static string CreateSignature(string queryString, string secret)
        {

            byte[] keyBytes = Encoding.UTF8.GetBytes(secret);
            byte[] queryStringBytes = Encoding.UTF8.GetBytes(queryString);
            HMACSHA256 hmacsha256 = new HMACSHA256(keyBytes);

            byte[] bytes = hmacsha256.ComputeHash(queryStringBytes);

            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public  static Candle ParseCandle(string candleString)
        {
            string i = candleString;
            Candle result = new Candle();
            i = candleString
                .Replace("[", "")
                .Replace("]","")
                .Replace("\"","");
            List<string> s = i.Split(@",").ToList();
            result.OpenTime_UnixTime =  long.Parse( s[0]);
            result.CloseTime_UnixTime = long.Parse(s[6]);
            result.OpenPrice =decimal.Parse(s[1]);
            result.ClosePrice = decimal.Parse(s[4]);
            result.Low = decimal.Parse(s[3]);
            result.High = decimal.Parse(s[2]);

            return result;
        }

        public static string IntervalToString(Interval interval)
        {
            string result = "";
            switch (interval)
            {
                case Interval.Minute_1:
                    result = "1m";
                    break;

                case Interval.Minute_3:
                    result = "3m";
                    break;

                case Interval.Minute_5:
                    result = "5m";
                    break;

                //case Interval.Minute_15:
                //    result = "15m";
                //    break;

                case Interval.Minute_30:
                    result = "30m";
                    break;


                case Interval.Hour_1:
                    result = "1h";
                    break;

                case Interval.Hour_2:
                    result = "2h";
                    break;

                case Interval.Hour_4:
                    result = "4h";
                    break;


                case Interval.Day_1:
                    result = "1d";
                    break;

                case Interval.Week_1:
                    result = "1w";
                    break;

                case Interval.Month_1:
                    result = "1M";
                    break;
            }



            return result;
        }
    }
}
