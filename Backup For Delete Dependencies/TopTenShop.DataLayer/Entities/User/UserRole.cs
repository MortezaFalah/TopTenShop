﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTenShop.DataLayer.Entities.User
{
    public class UserRole
    {
        public UserRole()
        {

        }
        [Key]
        public int Ur_Id { get; set; }

        public int RoleId { get; set; }

        public int UserId { get; set; }


        #region Navigation Peroperty
        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
        #endregion

    }
}
