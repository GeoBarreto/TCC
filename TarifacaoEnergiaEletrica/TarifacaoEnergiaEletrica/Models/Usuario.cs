using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarifacaoEnergiaEletrica.Models
{
    class Usuario
    {
        public String Email { get; set; }
        public int IdCliente { get; set; }
        public String CPF { get; set; }
        public String Nome { get; set; }
        public String Senha { get; set; }
        public bool Ativo { get; set; }
        public int Tipo { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
