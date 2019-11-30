using AeldreplejeCore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AeldreplejeCore.Core.Application
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);
    }
}
