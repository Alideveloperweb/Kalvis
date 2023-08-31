﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Common.Application
{
    public static class ConvertDate
    {
        public static string MiladiToShamsi(this DateTime? Date)
        {
            if (String.IsNullOrEmpty(Date.ToString()) ||
               String.IsNullOrWhiteSpace(Date.ToString()))
                return "";

            var pc = new PersianCalendar();
            return $"{pc.GetYear(Date.Value):0000}/{pc.GetMonth(Date.Value):00}/{pc.GetDayOfMonth(Date.Value):00}";
        }

        private static readonly string[] Fa = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
        private static readonly string[] En = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public static string ToEnglishNumber(this string FaNumber)
        {
            if (String.IsNullOrEmpty(FaNumber) ||
                String.IsNullOrWhiteSpace(FaNumber))
                return null;

            //1400/06/12
            for (int i = 0; i < 10; i++)
                FaNumber = FaNumber.Replace(Fa[i], En[i]);
            return FaNumber;
        }

        public static DateTime? ShamsiToMiladi(this string Date)
        {
            if (String.IsNullOrEmpty(Date) ||
        String.IsNullOrWhiteSpace(Date))
                return null;

            //1400/12/12
            Date = Date.ToEnglishNumber();
            var year = Convert.ToInt32(Date.Substring(0, 4));
            var month = Convert.ToInt32(Date.Substring(5, 2));
            var day = Convert.ToInt32(Date.Substring(8, 2));

            return new DateTime
                (year, month, day, new PersianCalendar());

        }
    }
}
