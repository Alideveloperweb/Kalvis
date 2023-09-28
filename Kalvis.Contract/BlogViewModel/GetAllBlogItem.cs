
namespace Kalvis.Contract.BlogViewModel
{
    public class GetAllBlogItem
    {
        public int BlogId { get; set; }
        public string BlogImage { get; set; }
        public string BlogTitle { get; set; }
        public string CreateDate { get; set; }
        public string LastUpdate { get; set; }
        public bool IsActive { get; set; }

    }
}
