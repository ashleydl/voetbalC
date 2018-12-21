
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voetbalC
{
    public class Verdeling
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public List<Opstelling> Opstelling { get; set; }

        public Verdeling()
        {
            Team1 = new Team();
            Team2 = new Team();
        }
    }
}
