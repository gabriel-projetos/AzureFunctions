using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Extensions
{
    public static class DateTimeExtension
    {
        public static double Timestamp(this DateTime time)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var unixDateTime = (time.ToUniversalTime() - epoch).TotalSeconds;

            return unixDateTime;
        }
    }
}
