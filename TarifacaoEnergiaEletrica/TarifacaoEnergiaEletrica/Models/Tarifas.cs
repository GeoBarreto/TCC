using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarifacaoEnergiaEletrica.Models
{
    public class Tarifas
    {
        
        public DateTime DataReferencia { get; set; }
        public int public int IdDistribuidora { get; set; }
        public String tipoConta { get; set; }
        public String bandeiraT { get; set; }
        public String classificação { get; set; }
        public double precoConsumoNP { get; set; }
        public double precoConsumoFP { get; set; }
        public double precoDemandaTUSD { get; set; }
        public double precoConsumoUltrapassagemNP { get; set; }
        public double precoConsumoUltrapassagemFP { get; set; }
        public double precoConsumoUltrapassagem { get; set; }
        public int IdTarifa { get; set; }
        
    }
}