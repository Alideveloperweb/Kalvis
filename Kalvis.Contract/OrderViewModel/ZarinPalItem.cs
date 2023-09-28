
namespace Kalvis.Contract.OrderViewModel
{
    public class ZarinPalItem
    {
        public long UserID { get; set; }
        public string UrlSite { get; set; }
        public string Redirect { get; set; }
        public string DisCountCode { get; set; }
    }

    public class VerificationZarinPalItem
    {
        public string Status { get; set; }
        public string Authority { get; set; }
        public long OrderID { get; set; }
        public string RefID { get; set; }
    }
}
