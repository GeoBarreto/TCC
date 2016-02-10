using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarifacaoEnergiaEletrica.Models
{
    public class Conta
    {
        public double demandaContratada { get; set; }
        public DateTime DataReferencia { get; set; }
        public int IdFabrica { get; set; }
        public String tipoConta { get; set; }
        public String bandeiraT { get; set; }
        public String classificação { get; set; }
        public double ConsumoNP { get; set; }
        public double ConsumoFP { get; set; }
        public double DemandaTUSD { get; set; }
        public double ConsumoUltrapassagemNP { get; set; }
        public double ConsumoUltrapassagemFP { get; set; }
        public double ConsumoUltrapassagem { get; set; }
        public int IdTarifa { get; set; }
        public double Total { get; set; }
    }
}
