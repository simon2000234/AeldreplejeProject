using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AeldreplejeCore.Core.Application.Validators;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Impl
{
    public class UserService : IUserService
    {
        private IUserRepo _userRepository;
        private IGroupRepo _groupRepo;

        public UserService(IUserRepo userRepository, IGroupRepo groupRepo = null)
        {
            _userRepository = userRepository;
            _groupRepo = groupRepo;
        }

        public User CreateUser(UserDTO user)
        {
            UserServiceValidator.ValidateUser(user);
            if (_groupRepo.GetGroup(user.Group.Id) == null)
            {
                throw new InvalidDataException("User most have a group that already exists");
            }
            return _userRepository.CreateUser(user);
        }

        public User DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public User UpdateUser(UserDTO user)
        {
            UserServiceValidator.ValidateUpdateUser(user);
            return _userRepository.UpdateUser(user);
        }
    }
}
