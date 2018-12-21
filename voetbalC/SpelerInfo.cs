using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voetbalC
{
    public class SpelerInfo
    {
        public string Naam { get; set; }
        public List<PositieInfo> PositieInfo { get; set; }
        
        public SpelerInfo()
        {
            PositieInfo = new List<PositieInfo>();
        }

        

    }
    // In deze classe slaan we de gegevens van de sterkte van de positie op
        public class PositieInfo
        {
            public Positie Positie { get; set; }
            public int PositieWaarde { get; set; }
        }
}
