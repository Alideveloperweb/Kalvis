
using System.ComponentModel.DataAnnotations;

namespace Kalvis.Contract.AccountViewModel
{
    public class RegisterItem
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfigrmPassword { get; set; }
    }
}
