using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Common.Application
{

    public static class GetValueArraye
    {
        public static string ArrayeGetValue(this ICollection<object> Route, int Value)
        {
            return Route.ToArray()
                   .GetValue(Value)
                   .ToString().ToLower();
        }
    }
}

