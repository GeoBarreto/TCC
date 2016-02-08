using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarifacaoEnergiaEletrica.Models
{
    class Cliente
    {
        public String nome;
        public String CNPJ;
        public String endereço;
        public List<Fabrica> fabricas=new List<Fabrica>();
    }
}
