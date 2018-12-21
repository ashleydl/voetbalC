using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voetbalC
{
    public class Team
    {
        public string Naam { get; set; }
        public List<SpelerInfo> Spelers { get; set; }

        public Team()
        {
            Spelers = new List<SpelerInfo>();
        }
    }
}
