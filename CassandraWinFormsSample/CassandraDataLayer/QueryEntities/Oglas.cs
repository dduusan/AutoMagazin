using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraDataLayer.QueryEntities
{
    public class Oglas
    {
        public string nazivAutomobila { get; set; }
        public string mestoprodaje { get; set; }
        public string prodavacMejl { get; set; }
        public string modelAutomobila { get; set; }
        public int godisteAutomobila { get; set; }
        public string tipMotora { get; set; }

        public double kubikaza { get; set; }

        public int brojlajkova { get; set; }
        public List<Narudzbina> narudzbine { get; set; }
    }
}
