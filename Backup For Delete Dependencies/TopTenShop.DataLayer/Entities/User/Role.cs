using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTenShop.DataLayer.Entities.User
{
    public class Role
    {

        public Role()
        {

        }
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display (Name ="نقش کاربر")]
        public int RoleTitle { get; set; }


        #region Navigation Peroperty

        public virtual List<UserRole> UserRole { get; set; }

        #endregion
    }
}
