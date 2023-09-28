
using Kalvis.Common.Application;

namespace Kalvis.Contract.AccountViewModel.Interface
{
    public interface IAccountApplication
    {
        OperationResult Login(LoginItem login);
        OperationResult LogOut();
        OperationResult Register(RegisterItem register);
        OperationResult ActiveEmail(long UserID, string ActiveCode);
    }
}
