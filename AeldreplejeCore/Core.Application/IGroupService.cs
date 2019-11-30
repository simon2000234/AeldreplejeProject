using System.Collections.Generic;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Impl
{
    public interface IGroupService
    {
        List<Group> GetAllGroups();
        Group GetGroup(int id);
        Group CreateGroup(Group group);
        Group UpdateGroup(Group group);
        Group DeleteGroup(int id);
    }
}