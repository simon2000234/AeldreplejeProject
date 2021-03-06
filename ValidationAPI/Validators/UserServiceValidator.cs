﻿using System.IO;
using ValidationAPI.Core.Entity;

namespace ValidationAPI.Validators
{
    public class UserServiceValidator
    {

        public static void ValidateUser(UserDTO user)
        {
            if (user == null)
            {
                throw new InvalidDataException("User most not be null");
            }

            if (string.IsNullOrEmpty(user.Name))
            {
                throw new InvalidDataException("User must have a name");
            }

            if(string.IsNullOrEmpty(user.Email))
            {
                throw new InvalidDataException("User must have an Email");
            }

            if (!user.Email.Contains("@"))
            {
                throw new InvalidDataException("User must have an @ in the Email");
            }

            if (!user.Email.Contains("."))
            {
                throw new InvalidDataException("User must end with .something in the Email");
            }

            if (containMultipleAdds(user.Email))
            {
                throw new InvalidDataException("User's email may only have one @ in them");
                
            }

            if (user.Group == null)
            {
                throw new InvalidDataException("User must have a group");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new InvalidDataException("User most have a password");
            }
        }

        public static void ValidateUpdateUser(UserDTO user)
        {
            ValidateUser(user);
            if (user.Id < 1)
            {
                throw new InvalidDataException("User must have a valid positive id to update");
            }
        }


        private static bool containMultipleAdds(string email)
        {
            char[] lettersInEmail = email.ToCharArray();
            int numberOffAdds = 0;


            foreach (var letter in lettersInEmail)
            {
                if (letter.Equals('@'))
                {
                    numberOffAdds++;
                }
            }

            if(numberOffAdds > 1)
            {
                return true;
            }

            return false;
        }
    }
}