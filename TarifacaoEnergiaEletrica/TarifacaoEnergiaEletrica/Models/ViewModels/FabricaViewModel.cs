using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarifacaoEnergiaEletrica.Models.ViewModels
{
    public partial class FabricaViewModel
    {
        [Key]
        public int IdFabrica { get; set; }
        public int IdCliente { get; set; }
        [Display(Name = "CNPF")]
        [DataType(DataType.Text)]
        public String CNPJ { get; set; }
        [Display(Name = "Endereço")]
        [DataType(DataType.Text)]
        public String Endereco { get; set; }
        public int IdDistribuidora { get; set; }
        [Display(Name = "Distribuidora")]
        [DataType(DataType.Text)]
        public String NomeDistribuidora { get; set; }
    }
}
