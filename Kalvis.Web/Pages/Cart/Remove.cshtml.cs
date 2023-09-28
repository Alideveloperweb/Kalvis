using Kalvis.Contract.OrderViewModel;
using Kalvis.Contract.OrderViewModel.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Pages.Cart
{
    public class RemoveModel : PageModel
    {
        #region Constracture
        private readonly IOrderApplication _OrderApp;
        public RemoveModel(IOrderApplication OrderApp)
        {
            this._OrderApp = OrderApp;
        }
        #endregion
        public IActionResult OnGet(long id)
        {
            CreateOrderItem orderItem = new();

            long UserID = long.Parse(User.FindFirst("userid").Value);

            orderItem.UserID = UserID;
            orderItem.CourseID = id;

            _OrderApp.UpdateCart(orderItem);

            return RedirectToPage("./Index");
        }
    }
}
