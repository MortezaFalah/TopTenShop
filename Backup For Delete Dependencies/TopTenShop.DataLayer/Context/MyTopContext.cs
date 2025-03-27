using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTenShop.DataLayer.Entities.User;

namespace TopTenShop.DataLayer.Context
{
    public class MyTopContext:DbContext
    {
        public MyTopContext(DbContextOptions<MyTopContext> Option) :base(Option)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
    }
}
