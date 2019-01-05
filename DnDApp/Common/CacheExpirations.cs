using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DnDApp.Common
{
    public class CacheExpirations
    {
        public static readonly TimeSpan DefaultTimeSpan = new TimeSpan(1, 0, 0, 0);
        public static readonly TimeSpan Episodes = DefaultTimeSpan;
        public static readonly TimeSpan Books = DefaultTimeSpan;
    }
}