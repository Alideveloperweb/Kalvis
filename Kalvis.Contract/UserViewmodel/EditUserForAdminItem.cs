using Kalvis.Common.Application;
using System.ComponentModel.DataAnnotations;


namespace Kalvis.Contract.UserViewmodel
{
    public class EditUserForAdminItem
    {
        [Display(Name = "شناسه")]
        [Required(ErrorMessage = RequiredMessage.Required)]
        public long UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = RequiredMessage.Required)]
        public string UserName { get; set; }

        [Display(Name = "نام اصلی")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "حذف")]
        public bool IsResmove { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "تلفن")]
        public string Phone { get; set; }

        [Display(Name = "پسورد")]
        public string Password { get; set; }

    }
}
