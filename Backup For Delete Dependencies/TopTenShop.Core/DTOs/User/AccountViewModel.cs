using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTenShop.Core.DTOs.User
{
    public class RegisterViewModel
    {

        [Display(Name ="نام کاربری")]
        [MinLength(8, ErrorMessage = "{0} حداقل می تواند 8 کرکتر باشد")]
        [MaxLength(30,ErrorMessage ="{0} حداکثر می تواند 30 کرکتر باشد")]
        [Required(ErrorMessage ="لطفا {0}را وارد نمایید")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [MinLength(15, ErrorMessage = "{0} حداقل می تواند 15 کرکتر باشد")]
        [MaxLength(150, ErrorMessage = "{0} حداکثر می تواند 150 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا {0}را وارد نمایید")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [MinLength(4, ErrorMessage = "{0} حداقل می تواند 6 کرکتر باشد")]
        [MaxLength(40, ErrorMessage = "{0} حداکثر می تواند 40 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا {0}را وارد نمایید")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [MinLength(4, ErrorMessage = "{0} حداقل می تواند 6 کرکتر باشد")]
        [MaxLength(40, ErrorMessage = "{0} حداکثر می تواند 40 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا {0}را وارد نمایید")]
        [Compare("Password",ErrorMessage ="{0} با کلمه عبور همخوانی ندارد")]
        public string RePassword { get; set; }

    }


    public class LoginViewModel
    {
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(150 , ErrorMessage ="{0} نمیتواند بیشتر از 150 کرکتر باشد")]
        [MinLength(5 ,ErrorMessage ="{0} نمیتواند کمتر از 5 کرکتر باشد")]
        [Display(Name = "ایمیل یا نام کاربری")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از 50 کرکتر باشد")]
        [MinLength(4, ErrorMessage = "{0} نمیتواند کمتر از 4 کرکتر باشد")]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; } = "";
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
