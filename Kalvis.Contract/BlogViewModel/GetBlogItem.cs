namespace Kalvis.Contract.BlogViewModel
{
    public class GetBlogItem
    {
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public string CategoryName { get; set; }
        public string BlogDescription { get; set; }
        public string Tags { get; set; }
        public bool IsComment { get; set; }
        public string LastUpdate { get; set; }
    }
}
