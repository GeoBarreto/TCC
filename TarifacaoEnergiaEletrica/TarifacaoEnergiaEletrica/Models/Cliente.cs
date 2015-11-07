using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarifacaoEnergiaEletrica.Models
{
    class Cliente
    {
        public int IdCliente { get; set; }
        public String Nome { get; set; }
        public String CNPJ { get; set; }
        public String RazaoSocial { get; set; }
        public String Endereco { get; set; }
    }
}
