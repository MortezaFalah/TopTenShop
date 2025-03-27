using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTenShop.Core.DTOs.User;
using TopTenShop.DataLayer.Entities.User;

namespace TopTenShop.Core.Services.Interface
{
    public interface IUserService
    {
        bool IsExistUserName(string username);

        bool IsExistEmail(string email);

        int AddUser(User user);

        User GetUserForLogin(LoginViewModel Login);

        bool ActiveAccount(string ActiveCode);
    }
}
