using System.Collections.Generic;
using AeldreplejeCore.Core.Application.Validators;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Impl
{
    public class GroupService: IGroupService
    {
        private IGroupRepo _groupepository;

        public GroupService(IGroupRepo groupRepository )
        {
            _groupepository = groupRepository;
        }

        public List<Group> GetAllGroups()
        {
            return _groupepository.GetAllGroups();
        }

        public Group GetGroup(int id)
        {
            return _groupepository.GetGroup(id);
        }

        public Group CreateGroup(Group group)
        {
            GroupServiceValidator.ValidateGroup(group);
            return _groupepository.CreateGroup(group);
        }

        public Group UpdateGroup(Group group)
        {
            GroupServiceValidator.ValidateUpdateGroup(group);
            return _groupepository.UpdateGroup(group);
        }

        public Group DeleteGroup(int id)
        {
            return _groupepository.DeleteGroup(id);
        }
    }
}