using System.ComponentModel.DataAnnotations;

namespace Kalvis.Contract.UserViewModel
{
    public class GetAllUserItem
    {
        [Display(Name = "شناسه")]
        public long UserId { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public string CreateDate { get; set; }

        [Display(Name = "موجودی")]
        public int Wallet { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "حذف")]
        public bool IsRemove { get; set; }

    }
}
