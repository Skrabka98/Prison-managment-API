﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonBack.Resources
{
    public class CellVM
    {
        public int Id { get; set; }
        public string CellNumber { get; set; }
        public int BedsCount { get; set; }
        public int IdPrison { get; set; }
        public int OccupiedBeds { get; set; }
        public int IdCellType { get; set; }

    }
}
