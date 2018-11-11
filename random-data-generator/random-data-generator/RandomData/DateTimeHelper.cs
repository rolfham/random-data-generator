using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_data_generator.RandomData
{
    public static class DateTimeHelper
    {
        private static DateTime _minDateTime = new DateTime(1900, 0, 1);
        private static DateTime _maxDateTime = new DateTime(2100, 0, 1);
        public static DateTime GetRandomDate(Random r)
        {
            var diff = (int)(_maxDateTime - _minDateTime).TotalDays;
            return _minDateTime.AddDays(r.Next(0, diff)).AddMinutes(r.Next(0, 59)).AddHours(r.Next(0, 23)); ;
        }

        public static DateTime GetFutureDate(Random r)
        {
            var diff = (int)(_maxDateTime - DateTime.Now).TotalDays;
            return _minDateTime.AddDays(r.Next(0, diff)).AddMinutes(r.Next(0, 59)).AddHours(r.Next(0,23));
        }

        public static DateTime GetPastDate(Random r)
        {
            var diff = (int)(DateTime.Now - _minDateTime).TotalDays;
            return _minDateTime.AddDays(r.Next(0, -1*diff)).AddMinutes(r.Next(0, 59)).AddHours(r.Next(0, 23)); ;
        }

        public static DateTime Next30Days(Random r)
        {
            return _minDateTime.AddDays(r.Next(1, 30)).AddMinutes(r.Next(0, 59)).AddHours(r.Next(0, 23)); ;
        }

        public static DateTime Last30Days(Random r)
        {
            return _minDateTime.AddDays(r.Next(1, -30)).AddMinutes(r.Next(0, 59)).AddHours(r.Next(0, 23)); ;
        }

    }
}
