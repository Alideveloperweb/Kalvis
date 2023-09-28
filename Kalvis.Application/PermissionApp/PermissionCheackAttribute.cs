
using Kalvis.Contract.PermissionViewModel.Interfcae;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kalvis.Application.PermissionApp
{
    public class PermissionCheackAttribute : AuthorizeAttribute
        , IAuthorizationFilter
    {
        #region Constracture
        private IPermissionApplication _PermissionApp;
        private readonly int _PermissionID = 0;
        public PermissionCheackAttribute(int PermissionID)
        {
            _PermissionID = PermissionID;
        }
        #endregion
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _PermissionApp = (IPermissionApplication)
                context.HttpContext.RequestServices.GetService(typeof(IPermissionApplication));

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                long UserID = long.Parse(context.HttpContext.User.FindFirst("userid").Value);

                if (!_PermissionApp.CheckPermission(_PermissionID, UserID))
                    context.Result = new RedirectResult("/Account/LogIn");
            }
            else
            {
                context.Result = new RedirectResult("/Account/LogIn");
            }

        }
    }
}
