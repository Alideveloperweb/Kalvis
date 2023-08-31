using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Common.Application
{
    public static class Generator
    {
        public static string Generator_Code(int Number)
        {
            return Guid.NewGuid().ToString()
                .Replace("-","").Substring(0,Number);
        }
    }
}
