using System.Collections.Generic;
using System.Linq;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace AeldreplejeInfrastructure.Repositories
{
    public class GroupRepo: IGroupRepo
    {
        private AeldrePlejeContext _context;

        public GroupRepo(AeldrePlejeContext context)
        {
            _context = context;
        }
        public List<Group> GetAllGroups()
        {
            return _context.Groups.Include(g => g.Users).ThenInclude(u => u.Group).ToList();
        }

        public Group GetGroup(int id)
        {
            return _context.Groups.Include(g => g.Users).ThenInclude(u => u.Group).FirstOrDefault(g => g.Id == id);
        }

        public Group CreateGroup(Group group)
        {
            _context.Attach(group).State = EntityState.Added;
            _context.SaveChanges();
            for (int i = 0; i < group.Users.Count; i++)
            {
                User user = _context.Users.FirstOrDefault(u => u.Id == group.Users[i].Id);
                user.Group = group;
                group.Users[i] = user;
                _context.Groups.Attach(group).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return group;
        }

        public Group UpdateGroup(Group group)
        {
            _context.Attach(group).State = EntityState.Modified;
            _context.Entry(group).Collection(g => g.Users).IsModified = true;

            var users = _context.Users.Where(u => u.Group.Id == group.Id && !group.Users.Exists(ul => ul.Id == u.Id ));

            foreach (var user in users)
            {
                user.Group = null;
                _context.Entry(user).Reference(u => u.Group).IsModified = true;
            }

            _context.SaveChanges();
            return group;
        }

        public Group DeleteGroup(int id)
        {
            var group = _context.Remove(new Group { Id = id }).Entity;
            _context.SaveChanges();
            return group;
        }
    }
}