using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kalvis.Common.Enum
{
    public enum CourselLevel
    {
        [Display(Name = "متوسط")]
        medium = 1,
        [Display(Name = "پیشرفته")]
        Advanced = 2,
        [Display(Name = "صفر تا صد")]
        Zero_to_hundred = 3,
    }
}
