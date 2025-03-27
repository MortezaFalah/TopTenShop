using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTenShop.DataLayer.Entities.User
{
    public class User
    {

        public User()
        {

        }
        [Key]
        public int UserId { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "کد فعال سازی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ActiveCode { get; set; }


        [Display(Name = "کاربر فعال شده است؟")]
        public bool IsActive { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "عکس کاربر")]
        public string UserAvatar { get; set; }

        #region Navigation Peroperty

        public virtual List<UserRole> UserRole { get; set; }

        #endregion
    }
}
