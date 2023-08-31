using Kalvis.Common.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kalvis.Contract.UserViewmodel
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
