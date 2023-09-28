using Kalvis.Common.Application;
using System.ComponentModel.DataAnnotations;


namespace Kalvis.Contract.UserViewModel
{
    public class EditPasswordItem
    {
        public long Userid { get; set; }

        [Display(Name = "پسورد فعلی")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = RequiredMessage.Required)]
        public string OldPassword { get; set; }

        [Display(Name = "پسورد جدید")]
        [Required(ErrorMessage = RequiredMessage.Required)]
        public string NewPassword { get; set; }

        [Display(Name = "تایید پسورد")]
        [Required(ErrorMessage = RequiredMessage.Required)]
        [Compare(nameof(NewPassword), ErrorMessage = RequiredMessage.Compare)]
        public string ConfirmPassword { get; set; }

    }
}
