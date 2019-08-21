using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Denis_Partner_Group.Domains
{
    public class PatrimonioDomain
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int NumeroTombo { get; set; }

        public int MarcaId { get; set; }
        public MarcaDomain Marca { get; set; }
    }
}
