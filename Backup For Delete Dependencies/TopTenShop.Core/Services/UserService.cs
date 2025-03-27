using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTenShop.Core.Convertors;
using TopTenShop.Core.DTOs.User;
using TopTenShop.Core.Generator;
using TopTenShop.Core.Security;
using TopTenShop.Core.Services.Interface;
using TopTenShop.DataLayer.Context;
using TopTenShop.DataLayer.Entities.User;

namespace TopTenShop.Core.Services
{
    public class UserService : IUserService
    {
        private MyTopContext _context;
        public UserService(MyTopContext context)

        {
            _context = context;

        }

        public bool ActiveAccount(string ActiveCode)
        {
            var user = _context.Users.Where(r => r.ActiveCode == ActiveCode).SingleOrDefault();
            if (user != null && user.IsActive == false)
            {
                user.IsActive = true;
                user.ActiveCode = NameGenerator.GenerateUniqCode();
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public User GetUserForLogin(LoginViewModel login)
        {
           string EmailorUserName = FixedText.FixEmail(login.Email);
            string HashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
        
            return _context.Users
                .FirstOrDefault(r => r.UserName == login.Email || r.Email == login.Email && r.Password == login.Password);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string username)
        {
           return _context.Users.Any(i=>i.UserName == username);
        }
    }
}
