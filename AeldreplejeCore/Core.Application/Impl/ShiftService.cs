using System.Collections.Generic;
using AeldreplejeCore.Core.Application.Validators;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Impl
{
    public class ShiftService: IShiftService
    {
        private IShiftRepo _shiftRepository;

        public ShiftService(IShiftRepo shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }
        
        public List<Shift> GetAllShifts()
        {
            return _shiftRepository.GetAllShifts();
        }

        public Shift GetShift(int id)
        {
            return _shiftRepository.GetShift(id);
        }

        public Shift CreateShift(Shift shift)
        {
            ShiftServiceValidator.ValidateShift(shift);
            return _shiftRepository.CreateShift(shift);
        }

        public Shift UpdateShift(Shift shift)
        {
            ShiftServiceValidator.ValidateUpdateShift(shift);
            return _shiftRepository.UpdateShift(shift);
        }

        public Shift DeleteShift(int id)
        {
            return _shiftRepository.DeleteShift(id);
        }
    }
}