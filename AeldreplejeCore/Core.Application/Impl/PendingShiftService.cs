using System.Collections.Generic;
using AeldreplejeCore.Core.Domain;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application.Impl
{
    public class PendingShiftService: IPendingShiftService
    {
        
        private IPendingShiftRepo _pendingShiftRepo;

        public PendingShiftService(IPendingShiftRepo pendingShiftRepo )
        {
            _pendingShiftRepo = pendingShiftRepo;
        }
        
        
        public List<PendingShift> GetAllPendingShift()
        {
            return _pendingShiftRepo.GetAllPendingShift();
        }

        public PendingShift GetPendingShift(int id)
        {
            return _pendingShiftRepo.GetPendingShift(id);
        }

        public PendingShift CreatePendingShift(PendingShift pendingShift)
        {
            return _pendingShiftRepo.CreatePendingShift(pendingShift);
        }

        public PendingShift UpdatePendingShift(PendingShift pendingShift)
        {
            return _pendingShiftRepo.UpdatePendingShift(pendingShift);
        }

        public PendingShift DeletePendingShift(int id)
        {
            return _pendingShiftRepo.DeletePendingShift(id);
        }
    }
}