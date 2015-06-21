using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEData
{
    public class Inscricoes
    {
        public int id { get; set; }
        public int status { get; set; }
        public Pessoas id_pessoa { get; set; }
        public Eventos id_evento { get; set; }
    }
}
