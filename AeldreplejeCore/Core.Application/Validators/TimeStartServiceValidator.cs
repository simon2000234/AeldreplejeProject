using System.IO;
using System.Runtime.InteropServices;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Validators
{
    public class TimeStartServiceValidator
    {
        public bool Validate(TimeStart timeStart)
        {
            if(timeStart == null)
            {
                throw new InvalidDataException("TimeStart can't be null");
            }

            if (string.IsNullOrEmpty(timeStart.timeStart))
            {
                throw new InvalidDataException("TimeStart can't be empty");
            }

            if (timeStart.timeStart.Length != 5)
            {
                throw new InvalidDataException("TimeStart string is too long/short, follow format HH:mm");
            }

            int hours;
            if (!int.TryParse(timeStart.timeStart.Substring(0, 2), out hours))
            {
                throw new InvalidDataException("TimeStart string has to be numbers");
            }

            int minutes;
            if (!int.TryParse(timeStart.timeStart.Substring(3, 2), out minutes))
            {
                throw new InvalidDataException("TimeStart string has to be numbers");
            }

            if (!timeStart.timeStart.Substring(2, 1).Equals(":"))
            {
                throw new InvalidDataException("TimeStart string has to be in format of HH:mm (ex 09:45)");
            }

            minutes = int.Parse(timeStart.timeStart.Substring(3, 2));
            if (minutes > 59 || minutes < 0)
            {
                throw new InvalidDataException("TimeStart string minutes has to be 00-59");
            }

            hours = int.Parse(timeStart.timeStart.Substring(0, 2));
            if (hours > 23 || hours < 0)
            {
                throw new InvalidDataException("TimeStart string hours has to be 00-23");
            }

            return true;
        }
    }
}