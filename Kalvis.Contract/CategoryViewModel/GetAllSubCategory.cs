using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalvis.Contract.CategoryViewModel
{
    public class GetAllSubCategory
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public int ParentId { get; set; }
    }
}
