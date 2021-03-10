using System.IO;
using ValidationAPI.Core.Entity;

namespace ValidationAPI.Validators
{
    public class GroupServiceValidator
    {
        public static void ValidateGroup(Group group)
        {
            if (group == null)
            {
                throw new InvalidDataException("Group most not be null");
            }

            if (string.IsNullOrEmpty(group.Type))
            {
                throw new InvalidDataException("Group must have a type");
            }
        }

        public static void ValidateUpdateGroup(Group group)
        {
            ValidateGroup(group);

            if (group.Id < 1)
            {
                throw new InvalidDataException("Group must have a valid positive id to update");
            }
        }
    }
}