using Denis_Partner_Group.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Denis_Partner_Group.Interfaces
{
    public interface IMarcaRepository
    {
        List<MarcaDomain> ListarTodos();

        void Cadastrar(MarcaDomain marca);
   
    }
}
