
using Kalvis.Common.Application;
using Microsoft.AspNetCore.Mvc;

namespace Kalvis.Web.Pages.ViewComponents
{
    public class OperationComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            OperationResult operationResult = new();
            if (TempData["OperationResult"] != null)
            {
                operationResult = Newtonsoft.Json.JsonConvert.
                    DeserializeObject<OperationResult>
                    (TempData["OperationResult"].ToString());
            }

            return View(operationResult);
        }
    }
}
