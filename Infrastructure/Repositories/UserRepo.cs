using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AeldreplejeInfrastructure.Helpers;

namespace AeldreplejeInfrastructure.Repositories
{
    public class UserRepo : IUserRepo
    {
        private AeldrePlejeContext _context;
        private IAuthenticationHelper _auth;

        public UserRepo(AeldrePlejeContext context, IAuthenticationHelper authentication)
        {
            _context = context;
            _auth = authentication;
        }

        public User CreateUser(UserDTO userDTO)
        {

            byte[] newPassHash, newPassSalt;
            _auth.CreatePasswordHash(userDTO.Password, out newPassHash, out newPassSalt);
            User user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                IsAdmin = userDTO.IsAdmin,
                Group = userDTO.Group,
                ProfilePicture = userDTO.ProfilePicture,
                PasswordHash = newPassHash,
                PasswordSalt = newPassSalt,
                PShifts = userDTO.PShifts,
                Role = userDTO.Role,
                Shifts = userDTO.Shifts
            };

            _context.Attach(user).State = EntityState.Added;
            _context.SaveChanges();

            Group group = _context.Groups.FirstOrDefault(g => g.Id == user.Group.Id);
            if (user != null)
            {
                group.Users.Add(user);
                user.Group = group;
            }
            _context.SaveChanges();

            return user;
        }

        public User DeleteUser(int id)
        {
            var user = _context.Remove(new User { Id = id }).Entity;
            _context.SaveChanges();
            return user;
        }

        public List<User> LogIn()
        {
            return _context.Users.ToList();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users
                .Include(u => u.Group)
                .Include(u => u.Shifts)
                .Include(u => u.PShifts)
                .ThenInclude(usp => usp.PendingShift)
                .ToList(); ;
        }

        public User GetUser(int id)
        {
            return _context.Users.Include(u => u.Group)
                .Include(u => u.Shifts)
                .Include(u => u.PShifts)
                .ThenInclude(usp => usp.PendingShift).FirstOrDefault(u => u.Id == id);
        }

        public User UpdateUser(UserDTO userDTO)
        {

            byte[] newPassHash, newPassSalt;
            _auth.CreatePasswordHash(userDTO.Password, out newPassHash, out newPassSalt);
            User user = new User
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Email = userDTO.Email,
                IsAdmin = userDTO.IsAdmin,
                PasswordHash = newPassHash,
                PasswordSalt = newPassSalt,
                Group = userDTO.Group,
                ProfilePicture = userDTO.ProfilePicture,
                PShifts = userDTO.PShifts,
                Role = userDTO.Role,
                Shifts = userDTO.Shifts
            };
            

            if (user.PShifts != null)
            {
                var newPShiftList = new List<UserPendingShift>(user.PShifts);
            }
            
            _context.Attach(user).State = EntityState.Modified;
            _context.Entry(user).Reference(u => u.Group).IsModified = true;
            if(user.Shifts != null)
            {
                _context.Entry(user).Collection(u => u.Shifts).IsModified = true;

                var shifts = _context.Shifts.Where(s => s.User.Id == user.Id && !user.Shifts.Exists(us => us.Id == s.Id));

                foreach (var shift in shifts)
                {
                    shift.User = null;
                    _context.Entry(shift).Reference(s => s.User).IsModified = true;
                }
            }
            

            if (user.PShifts != null)
            {
                _context.UserPendingShifts.RemoveRange(
                _context.UserPendingShifts.Where(usp => usp.UserId == user.Id));
            }


            _context.SaveChanges();
            return user;
        }
    }
}
