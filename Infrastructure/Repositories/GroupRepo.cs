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
            return _context.Groups.ToList();
        }

        public Group GetGroup(int id)
        {
            return _context.Groups.FirstOrDefault(g => g.Id == id);
        }

        public Group CreateGroup(Group group)
        {
            _context.Attach(group).State = EntityState.Added;
            _context.SaveChanges();
            return group;
        }

        public Group UpdateGroup(Group group)
        {
            _context.Attach(group).State = EntityState.Modified;
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