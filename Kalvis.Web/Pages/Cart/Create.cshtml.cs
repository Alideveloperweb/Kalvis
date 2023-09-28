using Kalvis.Common.Application;
using Kalvis.Contract.OrderViewModel;
using Kalvis.Contract.OrderViewModel.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kalvis.Web.Pages.Cart
{
    [Authorize]
    public class CreateModel : PageModel
    {
        #region Constracture
        private readonly IOrderApplication _OrderApp;
        public CreateModel(IOrderApplication OrderApp)
        {
            _OrderApp = OrderApp;
        }
        #endregion

        public IActionResult OnGet(long id)
        {
            long UserID = long.Parse(User.FindFirst("userid").Value);

            CreateOrderItem create = new()
            {
                CourseID = id,
                UserID = UserID
            };

            OperationResult operationResult =
                _OrderApp.CreateCart(create);

            return RedirectToPage("./Index");
        }
    }
}
