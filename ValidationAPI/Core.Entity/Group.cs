﻿using System.Collections.Generic;

namespace ValidationAPI.Core.Entity
{
    public class Group
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<User> Users { get; set; }

        public int QualificationNumber { get; set; }
    }
}