using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace AeldreplejeInfrastructure.Repositories
{
    public class UserRepo : IUserRepo
    {
        private AeldrePlejeContext _context;

        public UserRepo(AeldrePlejeContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Attach(user).State = EntityState.Added;
            _context.SaveChanges();
            return user;
        }

        public User DeleteUser(int id)
        {
            var user = _context.Remove(new User { Id = id }).Entity;
            _context.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users
                                .ToList(); ;
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User UpdateUser(User user)
        {
            _context.Attach(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }
    }
}
