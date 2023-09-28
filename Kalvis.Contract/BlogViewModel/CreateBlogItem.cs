using Kalvis.Contract.CategoryViewModel;
using Microsoft.AspNetCore.Http;

namespace Kalvis.Contract.BlogViewModel
{
    public class CreateBlogItem
    {
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public int CategoryId { get; set; }
        public string BlogDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsComment { get; set; }
        public string Tags { get; set; }
        public IFormFile Uploder { get; set; }
        public List<GetAllCategoryItem> GetAllCategory { get; set; }
    }
}
