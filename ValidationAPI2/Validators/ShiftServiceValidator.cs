using System;
using System.IO;
using ValidationAPI.Core.Entity;

namespace ValidationAPI.Validators
{
    public class ShiftServiceValidator
    {
        public static void ValidateShift(Shift shift)
        {
            if (shift == null)
            {
                throw new InvalidDataException("Shift most not be null");
            }

            if (shift.Date < DateTime.Now)
            {
                throw new InvalidDataException("Shift's date most be after now");
            }

            if (shift.TimeEnd < DateTime.Now)
            {
                throw new InvalidDataException("Shift's time end must be after now");
            }
            if (shift.TimeStart > shift.TimeEnd)
            {
                throw new InvalidDataException("Shift's TimeStart must be before TimeEnd");
            }

            if (shift.TimeStart < DateTime.Now)
            {
                throw new InvalidDataException("Shift's time start must be after now");
            }

        }

        public static void ValidateUpdateShift(Shift shift)
        {
            ValidateShift(shift);
            if (shift.Id < 1)
            {
                throw new InvalidDataException("Shift must a valid positive id");
            }
        }
    }
}