using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafitec.Cloud.Utils.ClassExtensions
{
    public static class DateTimeExtensions
    {
        public static bool DataValida(this DateTime data)
        {
            return (data.Date > new DateTime(0001, 1, 1).Date);
        }


        public static string ToStringOrDefault(this DateTime? data, string format, string defaultValue)
        {
            if (data != null)
            {
                return data.Value.ToString(format);
            }
            else
            {
                return String.IsNullOrEmpty(defaultValue) ? String.Empty : defaultValue;
            }
        }

        public static string ToStringOrDefault(this DateTime? data, string format)
        {
            return ToStringOrDefault(data, format, null);
        }

    }
}
