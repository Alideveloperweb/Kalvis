using Kalvis.Contract.DisCount.CourseDisCountViewModel.Interface;
using Kalvis.Contract.DisCountViewModel.CourseDisCountViewModel;
using Kalvis.Contract.OrderViewModel;
using Kalvis.Contract.OrderViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Pages.Cart
{

    public class ZarinPalModel : PageModel
    {
        #region Constracture
        private readonly ICourseDisCountApplication _DisCountApp;
        private readonly IOrderApplication _OrderRep;

        public ZarinPalModel(ICourseDisCountApplication DisCountApp,
            IOrderApplication OrderRep)
        {
            _DisCountApp = DisCountApp;
            _OrderRep = OrderRep;
        }
        #endregion
        public VerificationZarinPalItem Verification { get; set; }

        public IActionResult OnPost(string DisCountCode)
        {
            ZarinPalItem item = new();

            var Http = HttpContext.Request.Scheme;
            var UrlSite = HttpContext.Request.Host.Host;
            var Port = HttpContext.Request.Host.Port;

            long UserID = long.Parse(User.FindFirst("userid").Value);

            item.UrlSite = Http + "://" + UrlSite + ":" + Port;
            item.UserID = UserID;
            item.DisCountCode = DisCountCode;
            ZarinPalItem zarin = _OrderRep.ZarinPal(item);
            if (zarin == null)
                return Page();

            return Redirect(zarin.Redirect);

        }

        public IActionResult OnGetUrlBack(long id)
        {
            if (id <= 0)
                return Page();

            Verification = new();

            if (HttpContext.Request.Query["Status"] != "" &&
                 HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                 && HttpContext.Request.Query["Authority"] != "")
            {
                VerificationZarinPalItem pay = new()
                {
                    Authority = HttpContext.Request.Query["Authority"].ToString(),
                    OrderID = id,
                    Status = HttpContext.Request.Query["Status"].ToString(),
                };
                Verification = _OrderRep.VerificationPay(pay);
            }
            else
            {
                Verification.Status = "101";
            }

            return Page();
        }


        public IActionResult OnGetDisCount(string discountcode)
        {
            DisCountOrderItem orderItem = new()
            {
                DisCountCode = discountcode,
            };
            var DisCount = _DisCountApp.DisCountOrder(orderItem);

            return new JsonResult(new DisCountOrderItem
            {
                Status = DisCount.Status,
                Message = DisCount.Message,
                Price = DisCount.Price,
            });

        }
    }
}
