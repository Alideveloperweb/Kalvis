using Kalvis.Contract.CategoryViewModel;
using Microsoft.AspNetCore.Http;

namespace Kalvis.Contract.BlogViewModel
{
    public class EditBlogItem
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public int CategoryId { get; set; }
        public string BlogDes { get; set; }
        public bool IsActive { get; set; }
        public bool IsComment { get; set; }
        public string Tags { get; set; }
        public IFormFile Uploder { get; set; }
        public List<GetAllCategoryItem> GetAllCategory { get; set; }
    }
}
