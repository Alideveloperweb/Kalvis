using Kalvis.Common.Application;
using Kalvis.Common.Security;
using Kalvis.Common.Sender;
using Kalvis.Contract.AccountViewModel;
using Kalvis.Contract.AccountViewModel.Interface;
using Kalvis.Contract.UserViewModel;
using Kalvis.Domain.EducationEntities.UserEntities;
using Kalvis.Domain.EducationEntities.UserEntities.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Kalvis.Application.AccountApp
{
    public class AccountApplication : IAccountApplication
    {
        #region Constracture
        private readonly IUserRepository _UserRepp;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IViewRenderService _renderService;
        public AccountApplication(
            IUserRepository UserRepp,
            IHttpContextAccessor contextAccessor,
            IViewRenderService renderService)
        {
            this._UserRepp = UserRepp;
            _renderService = renderService;
            this._contextAccessor = contextAccessor;
        }


        #endregion

        public OperationResult Login(LoginItem login)
        {
            OperationResult operationResult = new();

            GetUserItem getUser = _UserRepp.FindUserByUserName(login.UserName);

            if (getUser == null)
                return operationResult.Failed(Operation.Nullabel, AccountMassage.UserNotFound);

            if (getUser.Password != login.Password.EncodePasswordMd5())
                return operationResult.Failed(Operation.Error, AccountMassage.UserNotFound);

            if (getUser.IsRemove)
                return operationResult.Failed(Operation.Error, AccountMassage.UserNotFound);

            if (!getUser.IsActive)
                return operationResult.Failed(Operation.Nullabel, AccountMassage.NotActive);

            var claim = new List<Claim>()
            {
                new Claim("userid",getUser.UserId.ToString()),
                new Claim("username",getUser.UserName),
                new Claim("email",getUser.Email),
            };

            var Identity = new ClaimsIdentity(claim, "Cookies");
            var principal = new ClaimsPrincipal(Identity);
            var Properties = new AuthenticationProperties
            {
                IsPersistent = login.IsPersistent,
            };

            _contextAccessor.HttpContext.SignInAsync(principal, Properties);
            return operationResult.Success(Operation.Success, AccountMassage.LogInUser);
        }

        public OperationResult LogOut()
        {
            OperationResult operationResult = new();
            _contextAccessor.HttpContext.SignOutAsync();
            return operationResult.Success(Operation.Success, AccountMassage.LogOutUser);

        }

        public OperationResult Register(RegisterItem register)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("حساب");

            if (_UserRepp.Exist(x => x.UserName == register.UserName))
                return operationResult.Failed(Operation.Dublicade, message.Dublicate("نام"));

            User user = new(register.UserName, register.Email, "", register.Password
                .EncodePasswordMd5());


            bool Create = _UserRepp.Create(user);
            if (!Create)
                return operationResult.Failed(Operation.Error, message.ErrorCreate());

            bool save = _UserRepp.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            var url = _contextAccessor.HttpContext.Request.Scheme + "://" +
                _contextAccessor.HttpContext.Request.Host.Value + "/" +
                "Account/Register?handler=Active";

            var body = _renderService.RenderToStringAsync("_ActiveEmail",
                url + "&&CodeActive=" + user.ActiveCode + "&&UserID=" + user.Id);

            bool Sendemail = SendEmail.Send(user.Email, "فعال سازی حساب کاربری", body);

            return operationResult.Success(Operation.Success, message.Create());


        }

        public OperationResult ActiveEmail(long UserID, string ActiveCode)
        {
            OperationResult operationResult = new();
            ApplicationMessage message = new("حساب");

            User user = _UserRepp.Get(UserID);
            if (user == null)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            if (user.ActiveCode != ActiveCode)
                return operationResult.Failed(Operation.Nullabel, message.Nullabele());

            user.ActiveAccount();

            bool Update = _UserRepp.Update(user);
            if (!Update)
                return operationResult.Failed(Operation.Error, message.ErrorUpdate());

            bool save = _UserRepp.SaveChanges();
            if (!save)
                return operationResult.Failed(Operation.Error, message.ErrorSave());

            return operationResult.Success(Operation.Success, message.Update());

        }

    }
}
