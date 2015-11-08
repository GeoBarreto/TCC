using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TarifacaoEnergiaEletrica.Models
{
    public partial class Fabrica
    {
        public int IdFabrica { get; set; }
        public int IdCliente { get; set; }
        public String CNPJ { get; set; }
        public String Endereco { get; set; }
    }
}
