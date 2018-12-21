﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voetbalC
{
    public class Opstelling
    {
        public int OpstellingID { get; set; }
        public List<PositieInfo> PositieInfo { get; set; }

        public Opstelling()
        {
            PositieInfo = new List<PositieInfo>();
        }
    }
    // In deze classe slaan we het aantal per positie voor de opstelling op
        public class OpstellingInfo
        {
        public Positie Positie { get; set; }
        public int PositieAantal { get; set; }
        }

   
}