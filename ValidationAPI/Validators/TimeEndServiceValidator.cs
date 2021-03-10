using System.IO;
using ValidationAPI.Core.Entity;

namespace ValidationAPI.Validators
{
    public class TimeEndServiceValidator
    {
        public bool Validate(TimeEnd timeEnd)
        {
            if (timeEnd == null)
            {
                throw new InvalidDataException("TimeEnd can't be null");
            }

            if (string.IsNullOrEmpty(timeEnd.timeEnd))
            {
                throw new InvalidDataException("TimeEnd can't be empty");
            }

            if (timeEnd.timeEnd.Length != 5)
            {
                throw new InvalidDataException("TimeEnd string is too long/short, follow format HH:mm");
            }

            int hours;
            if (!int.TryParse(timeEnd.timeEnd.Substring(0, 2), out hours))
            {
                throw new InvalidDataException("TimeEnd string has to be numbers");
            }

            int minutes;
            if (!int.TryParse(timeEnd.timeEnd.Substring(3, 2), out minutes))
            {
                throw new InvalidDataException("TimeEnd string has to be numbers");
            }

            if (!timeEnd.timeEnd.Substring(2, 1).Equals(":"))
            {
                throw new InvalidDataException("TimeEnd string has to be in format of HH:mm (ex 09:45)");
            }

            minutes = int.Parse(timeEnd.timeEnd.Substring(3, 2));
            if (minutes > 59 || minutes < 0)
            {
                throw new InvalidDataException("TimeEnd string minutes has to be 00-59");
            }

            hours = int.Parse(timeEnd.timeEnd.Substring(0, 2));
            if (hours > 23 || hours < 0)
            {
                throw new InvalidDataException("TimeEnd string hours has to be 00-23");
            }

            return true;
        }
    }
}