using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEData
{
   public class Eventos
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime data { get; set; }
        public string cidade { get; set; }
        public int qtd_horas { get; set; }
        public string descricao { get; set; }
    }
}
