﻿using System.Collections.Generic;

namespace ValidationAPI.Core.Entity
{
    public class PendingShift
    {
        public int Id { get; set; }
        public Shift Shift { get; set; }
        public int? ShiftId { get; set; }
        public List<UserPendingShift> Users { get; set; }
    }
}