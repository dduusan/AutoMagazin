using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraDataLayer.QueryEntities
{
   public class Narudzbina
    {
        public string narudzbinaId { get; set; }
        public string prodavacId { get; set; }
        public string kupacId { get; set; }
        public string oglasId { get; set; }
        public int odobrena { get; set; }
    }
}
