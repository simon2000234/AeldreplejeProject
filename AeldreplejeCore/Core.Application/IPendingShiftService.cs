using System.Collections.Generic;
using AeldreplejeCore.Core.Entity;

namespace AeldreplejeCore.Core.Application
{
    public interface IPendingShiftService
    {
        List<PendingShift> GetAllPendingShift();
        PendingShift GetPendingShift(int id);
        PendingShift CreatePendingShift(PendingShift pendingShift);
        PendingShift UpdatePendingShift(PendingShift pendingShift);
        PendingShift DeletePendingShift(int id);
        
    }
}