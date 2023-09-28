using Kalvis.Common.Application;
using System.ComponentModel.DataAnnotations;

namespace Kalvis.Contract.UserViewModel
{
    public class CreateUserItem
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = RequiredMessage.Required)]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "تلفن")]
        public string Phone { get; set; }

        [Display(Name = "پسورد")]
        public string Password { get; set; }

    }
}
