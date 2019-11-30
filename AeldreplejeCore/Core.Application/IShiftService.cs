using System.Collections.Generic;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application
{
    public interface IShiftService
    {
        List<Shift> GetAllShifts();
        Shift GetShift(int id);
        Shift CreateShift(Shift shift);
        Shift UpdateShift(Shift shift);
        Shift DeleteShift(int id);
    }
}