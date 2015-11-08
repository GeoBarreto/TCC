using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TarifacaoEnergiaEletrica.Models
{
    public partial class Usuario
    {
        public String Email { get; set; }
        [Required(ErrorMessage = "Informe email")]
        public int IdCliente { get; set; }
        public String CPF { get; set; }
        public String Nome { get; set; }
        public String Senha { get; set; }
        [Required(ErrorMessage = "Informe Senha")]
        public bool Ativo { get; set; }
        public int Tipo { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
